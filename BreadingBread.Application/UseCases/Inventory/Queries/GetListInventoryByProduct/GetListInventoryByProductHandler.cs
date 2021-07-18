using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetListInventoryByProduct
{
    public class GetListInventoryByProductHandler : IRequestHandler<GetListInventoryByProductQuery, GetListInventoryByProductResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetListInventoryByProductHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetListInventoryByProductResponse> Handle(GetListInventoryByProductQuery request, CancellationToken cancellationToken)
        {
            var currentInventory = await db.Inventory
                        .Where(el => el.IdProduct == request.IdProduct
                        && el.IdSaleUser == request.IdSaleUser)
                        .Select(el => new InventoryDTO
                        {
                            IdInventory = el.Id,
                            IdProduct = el.IdProduct,
                            IdSaleUser = el.IdSaleUser,
                            InitalCantity = el.InitalCantity
                        })
                         .ToListAsync(cancellationToken);

            return new GetListInventoryByProductResponse { Inventory = currentInventory };
        }
    }
}
