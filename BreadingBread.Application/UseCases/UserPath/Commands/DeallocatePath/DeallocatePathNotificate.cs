using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
            private readonly IHostingEnvironment server;
            private readonly IExcelService excel;
            private readonly IBreadingBreadDbContext db;

            public DeallocatePathHandler(IEmailService emailService, IHostingEnvironment server, IExcelService excel, IBreadingBreadDbContext db)
            {
                this.emailService = emailService;
                this.server = server;
                this.excel = excel;
                this.db = db;
            }

            public async Task Handle(DeallocatePathNotificate notification, CancellationToken cancellationToken)
            {
                var userSale = await db.UserSale.FirstOrDefaultAsync(u => u.Id == notification.IdUserSale);
                if (userSale == null)
                    throw new NotFoundException("No se encontro la ruta de venta ", notification.IdUserSale);

                var ventas = userSale.Sales.Select(el => new
                {
                    Tienda = "Nombre",
                    Productos = el.Products.Select(p => p.Product.Name),
                    Devoluciones = el.Products.Select(p => p.Product.Name)
                }).ToList();

                ventas.AddRange(userSale.Sales.Select(el => new
                {
                    Tienda = el.StoreVisited.Name,
                    Productos = el.Products.Select(p => p.Cantity.ToString()),
                    Devoluciones = el.Products.Select(p => p.ReturnCantity.ToString())
                }).ToList());

                var reporte = excel.FromObjectList(ventas, 9, 1, false);

                reporte.Add(new ExcelCellAux(2, 4, userSale.VisitedDate.ToString("dd-MMMM-yyyy")));
                reporte.Add(new ExcelCellAux(3, 4, "Alberto Espinoza Morelos"));

                var fileName = $"Ruta {userSale.Path.Name} {userSale.VisitedDate.ToString("yyyy-MM-dd")}";

                var filePath = System.IO.Path.Combine(server.WebRootPath, "/Reportes/PlantillaBasico.xlsx");
                var file = excel.AsExcel(reporte, filePath);
                await emailService.SendAsync(new Email
                {
                    To = "spartan73rmy12@gmail.com",
                    Body = $"Hola",
                    From = "Panaderia",
                    Subject = $"Ruta {userSale.Path.Name}, reporte de ventas",
                    IsBodyHtml = true,
                    FileName = fileName,
                    Attachment = file
                });
                var a = file;
            }
        }
    }
}
