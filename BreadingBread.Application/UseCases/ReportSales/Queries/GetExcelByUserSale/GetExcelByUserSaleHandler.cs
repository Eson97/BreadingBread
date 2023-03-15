using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale
{
    public class GetExcelByUserSaleHandler : IRequestHandler<GetExcelByUserSaleQuery, GetExcelByUserSaleResponse>
    {
        private readonly IExcelService excel;

        public GetExcelByUserSaleHandler(IExcelService excel)
        {
            this.excel = excel;
        }


        public Task<GetExcelByUserSaleResponse> Handle(GetExcelByUserSaleQuery request, CancellationToken cancellationToken)
        {
            var products = request.Sales.SelectMany(p => p.Products
                    .Select(product => new Tuple<int, string>(product.IdProduct, product.Product.Name)))
                    .Distinct(new ProductComparer())
                    .OrderBy(p => p.Item2);

            var salesByStore = request.Sales.GroupBy(s => s.IdStore).ToDictionary(sale => sale.Key,
                sale => sale.SelectMany(p => p.Products).OrderBy(p => p.Product.Name));

            var stores = request.Sales.GroupBy(store => store.IdStore)
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
                        .Sum(s => (s.Cantity - s.ReturnCantity) * s.UnitPrice - s.Discount).ToString();

                    row.Add(money);
                }
                var total = salesByStore[store].Sum(s => (s.Cantity - s.ReturnCantity) * s.UnitPrice - s.Discount).ToString();
                //Los productos estan en orden
                row.Add(total);

                report.Add(row);
                row = new List<string>();
            }
            var reporte = excel.FromObjectMatrix(report, 6, 1, false);

            reporte.Add(new ExcelCellAux(2, 3, request.UserSale.Path.Name));
            reporte.Add(new ExcelCellAux(3, 3, request.UserSale.VisitedDate.ToString("dd-MMMM-yyyy")));
            reporte.Add(new ExcelCellAux(4, 3, request.UserSale.User.Name));

            var fileName = $"Ruta {request.UserSale.Path.Name} {request.UserSale.VisitedDate.ToString("yyyy-MM-dd")}.xlsx";

            var parent = Directory.GetParent(Directory.GetCurrentDirectory());
            var filePath = System.IO.Path.Combine(parent.FullName, "BreadingBread.Infraestructure", "Reportes", "PlantillaBasico.xlsx");
            var absoluteFilePath = new Uri(filePath).LocalPath;

            var file = excel.AsExcel(reporte, absoluteFilePath);

            return Task.FromResult(new GetExcelByUserSaleResponse
            {
                File = file,
                FileName = fileName,
            });
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
