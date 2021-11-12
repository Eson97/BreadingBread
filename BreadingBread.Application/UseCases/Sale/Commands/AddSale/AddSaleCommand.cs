using MediatR;
using System.Collections.Generic;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleCommand : IRequest<AddSaleResponse>
    {
        public int IdPath { get; set; }
        public int IdStore { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public decimal Total { get; set; }
        public string Commentary { get; set; }

        public List<Product> Products { get; set; }

        public class Product
        {
            public int IdProduct { get; set; }
            public int Cantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Total { get; set; }
            public int? IdPromo { get; set; }
            public int? PromoCantity { get; set; }
            public int? ReturnCantity { get; set; }
            public decimal? Discount { get; set; }

        }
    }
}
