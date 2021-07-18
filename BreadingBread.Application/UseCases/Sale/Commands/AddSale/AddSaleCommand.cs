using MediatR;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleCommand : IRequest<AddSaleResponse>
    {
        public int IdUserSale { get; set; }
        public int IdStore { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public decimal Total { get; set; }
        public string? Commentary { get; set; }
    }
}
