using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using BreadingBread.Domain.Entities;
using MediatR;
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
                    var products = notification.Sales.SelectMany(p => p.Products
                    .Select(product => new Tuple<int, string>(product.IdProduct, product.Product.Name)))
                    .Distinct(new ProductComparer())
                    .OrderBy(p => p.Item2).ToList();

                    var salesByStore = notification.Sales.GroupBy(s => s.IdStore).ToDictionary(sale => sale.Key,
                        sale => sale.SelectMany(p => p.Products).OrderBy(p => p.Product.Name));

                    var stores = notification.Sales.GroupBy(store => store.IdStore)
                        .ToDictionary(store => store.Key, store => store.Select(s => s.StoreVisited).FirstOrDefault());

                    var report = new List<List<string>>();
                    var row = new List<string>();

                    //Se agregan los nombres de los productos por todas las tiendas
                    row.Add("Nombre");
                    row.AddRange(products.Select(p => p.Item2));

                    report.Add(row);
                    row.Add("Total");
                    row = new List<string>();
                    foreach (var store in stores.Keys)
                    {
                        //Se agrega el nombre de la tienda en la primer columna
                        row.Add(stores[store]?.Name ?? "Desconocido");

                        foreach (var product in products)
                        {
                            var money = salesByStore[store]
                                .Where(p => p.IdProduct == product.Item1)
                                .Sum(s => (((s.Cantity - s.ReturnCantity) * s.UnitPrice) - s.Discount)).ToString();

                            row.Add(money);
                        }
                        var total = salesByStore[store].Sum(s => (((s.Cantity - s.ReturnCantity) * s.UnitPrice) - s.Discount)).ToString();
                        //Los productos estan en orden
                        row.Add(total);

                        report.Add(row);
                        row = new List<string>();
                    }
                    var reporte = excelService.FromObjectMatrix(report, 6, 1, false);

                    reporte.Add(new ExcelCellAux(2, 3, notification.UserSale.Path.Name));
                    reporte.Add(new ExcelCellAux(3, 3, notification.UserSale.VisitedDate.ToString("dd-MMMM-yyyy")));
                    reporte.Add(new ExcelCellAux(4, 3, notification.UserSale.User.Name));

                    var fileName = $"Ruta {notification.UserSale.Path.Name} {notification.UserSale.VisitedDate.ToString("yyyy-MM-dd")}.xlsx";

                    var parent = Directory.GetParent(Directory.GetCurrentDirectory());
                    var filePath = System.IO.Path.Combine(parent.FullName, "BreadingBread.Infraestructure", "Reportes", "PlantillaBasico.xlsx");
                    var absoluteFilePath = new Uri(filePath).AbsolutePath;

                    var file = excelService.AsExcel(reporte, absoluteFilePath);

                    var taskSendEmails = new List<Task>();
                    foreach (var usertNotification in notification.UsersToNotificate)
                    {
                        var email = new Email
                        {
                            To = "spartan.73rmy12@gmail.com",
                            NameTo = usertNotification.Name,
                            Body = $"Hola {usertNotification.Name} este es el reporte de ventas del repartidor {notification.UserSale.User.Name}" +
                            $"<br/>La ruta se creo el {notification.UserSale.Created.ToString("yyyy-MM-dd")} a las {notification.UserSale.Created.ToString("t")}",
                            From = "Panaderia San Antonio",
                            Subject = $"{notification.UserSale.VisitedDate.ToString("yyyy-MM-dd")}, reporte de ventas de la ruta {notification.UserSale.Path.Name}",
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

        class ProductComparer : IEqualityComparer<Tuple<int, string>>
        {
            public bool Equals(Tuple<int, string> x, Tuple<int, string> y) => x.Item1 == y.Item1;

            public int GetHashCode(Tuple<int, string> obj) => obj.Item1.GetHashCode();
        }
    }
}
