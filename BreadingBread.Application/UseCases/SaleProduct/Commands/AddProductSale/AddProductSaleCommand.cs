using MediatR;

namespace BreadingBread.Application.UseCases.SaleProduct.Commands.AddProductSale
{
    public class AddProductSaleCommand : IRequest<AddProductSaleResponse>
    {
        public int IdSale { get; set; }
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
