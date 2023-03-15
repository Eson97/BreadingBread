using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale;
using BreadingBread.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath
{
    public class DeallocatePathNotificate : INotification
    {
        public int IdUserSale { get; set; }
        public List<User> UsersToNotificate { get; set; }
        public UserSale UserSale { get; set; }
        public List<Domain.Entities.Sale> Sales { get; set; }

        public class DeallocatePathHandler : INotificationHandler<DeallocatePathNotificate>
        {
            private readonly IEmailService emailService;
            private readonly IExcelService excelService;

            public DeallocatePathHandler(IEmailService emailService, IExcelService excel)
            {
                this.emailService = emailService;
                this.excelService = excel;
            }

            public async Task Handle(DeallocatePathNotificate notification, CancellationToken cancellationToken)
            {
                try
                {
                    var query = new GetExcelByUserSaleQuery(notification.IdUserSale, notification.UserSale, notification.Sales);
                    var handler = new GetExcelByUserSaleHandler(excelService);
                    var response = await handler.Handle(query, cancellationToken);

                    if (response?.File == null || string.IsNullOrEmpty(response?.FileName))
                    { return; }

                    var salesMan = notification?.UserSale?.Path?.Name ?? "Desconocido";
                    var pathTime = notification?.UserSale?.Created.ToString("t");
                    var visitedDate = notification?.UserSale?.VisitedDate.ToString("yyyy-MM-dd");
                    var pathDate = notification?.UserSale?.Created.ToString("yyyy-MM-dd");
                    var taskSendEmails = new List<Task>();
                    foreach (var usertNotification in notification.UsersToNotificate)
                    {
                        var email = new Email
                        {
                            To = "spartan.73rmy12@gmail.com",
                            NameTo = usertNotification?.Name ?? "Desconocido",
                            Body = $"Hola {usertNotification?.Name ?? "Desconocido"} este es el reporte de ventas del repartidor {salesMan}" +
                            $"<br/>La ruta se creo el {pathDate} a las {pathTime}",
                            From = "Panaderia San Antonio",
                            Subject = $"{visitedDate}, reporte de ventas de la ruta {salesMan}",
                            IsBodyHtml = true,
                            Attachment = response.File,
                            FileName = response.FileName,
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
    }
}
