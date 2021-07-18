using MediatR;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetListInventoryByProduct
{
    public class GetListInventoryByProductQuery : IRequest<GetListInventoryByProductResponse>
    {
        public int IdProduct { get; set; }
        public int IdSaleUser { get; set; }
    }
}
