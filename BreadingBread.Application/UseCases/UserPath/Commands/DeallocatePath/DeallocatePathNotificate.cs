using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath
{
    public class DeallocatePathNotificate : INotification
    {
        public int IdUserSale { get; set; }
        public class DeallocatePathHandler : INotificationHandler<DeallocatePathNotificate>
        {
            private readonly IEmailService emailService;
            private readonly IExcelService excelService;
            private readonly IBreadingBreadDbContext db;

            public DeallocatePathHandler(IEmailService emailService, IExcelService excel, IBreadingBreadDbContext db)
            {
                this.emailService = emailService;
                this.excelService = excel;
                this.db = db;
            }

            public async Task Handle(DeallocatePathNotificate notification, CancellationToken cancellationToken)
            {
                try
                {
                    var userSale = await db.UserSale.FirstOrDefaultAsync(u => u.Id == notification.IdUserSale);
                    if (userSale == null)
                        throw new NotFoundException("No se encontro la ruta de venta ", notification.IdUserSale);

                    var usersToNotificate = await db.User
                        .Where(el => el.Aproved && el.UserType == Domain.Enums.UserType.Admin)
                        .ToListAsync();

                    var ventasUsuario = await db.Sale
                           .Include(s => s.StoreVisited)
                           .Where(s => s.IdUserSale == userSale.Id)
                          .ToListAsync();

                    var report = new List<List<string>>();

                    var headers = new List<string>();
                    headers.Add("Nombre");
                    foreach (var product in ventasUsuario)
                        headers.AddRange(product.Products.Select(p => p.Product.Name).ToList());
                    report.Add(headers);

                    foreach (var currentSale in ventasUsuario)
                    {
                        var row = new List<string>();
                        row.Add(currentSale.StoreVisited.Name);
                        row.AddRange(currentSale.Products.Select(p => p.Cantity.ToString()).ToList());
                    }

                    var reporte = excelService.FromObjectList(report, 6, 1, false);

                    reporte.Add(new ExcelCellAux(2, 4, userSale.VisitedDate.ToString("dd-MMMM-yyyy")));
                    reporte.Add(new ExcelCellAux(3, 4, "Alberto Espinoza Morelos"));

                    var fileName = $"Ruta {userSale.Path.Name} {userSale.VisitedDate.ToString("yyyy-MM-dd")}.xlsx";

                    var parent = Directory.GetParent(Directory.GetCurrentDirectory());
                    var filePath = System.IO.Path.Combine(parent.FullName, "BreadingBread.Infraestructure", "Reportes", "PlantillaBasico.xlsx");
                    var absoluteFilePath = new Uri(filePath).AbsolutePath;

                    var file = excelService.AsExcel(reporte, absoluteFilePath);

                    var taskSendEmails = new List<Task>();
                    foreach (var usertNotification in usersToNotificate)
                    {
                        var email = new Email
                        {
                            To = "spartan.73rmy12@gmail.com",
                            NameTo = usertNotification.Name,
                            Body = $"Hola {usertNotification.Name}",
                            From = "Panaderia San Antonio",
                            Subject = $"{userSale.Path.Name}, reporte de ventas",
                            IsBodyHtml = true,
                            Attachment = file,
                            FileName = fileName,
                        };

                        var sendEmails = emailService.SendAsync(email);
                        taskSendEmails.Add(sendEmails);
                    }

                    await taskSendEmails.FirstOrDefault();
                    //Task.WaitAll(taskSendEmails);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        class ReportDTO
        {
            public List<List<ItemDTO>> ReportData { get; set; }
        }

        class ItemDTO
        {
            public string Data { get; set; }
        }
    }
}
