using BreadingBread.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BreadingBread.Application.Exceptions;
using BreadingBread.Domain.Entities;

namespace BreadingBread.Application.UseCases.Inventory.Commands.AddProductToInventory
{
    public class AddProductToInventoryHandler : IRequestHandler<AddProductToInventoryCommand, AddProductToInventoryResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AddProductToInventoryHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AddProductToInventoryResponse> Handle(AddProductToInventoryCommand request, CancellationToken cancellationToken)
        {
            var product = await db.Product.AnyAsync(el => el.Id == request.IdProduct);
            if (!product)
                throw new NotFoundException(nameof(Product), request.IdProduct);

            var userSale = await db.UserSale.AnyAsync(el => el.Id == request.IdSaleUser, cancellationToken);
            if (!userSale)
                throw new NotFoundException(nameof(UserSale), request.IdSaleUser);

            var exist = await db.Inventory
            .FirstOrDefaultAsync(el => el.IdProduct == request.IdProduct
            && el.IdSaleUser == request.IdSaleUser, cancellationToken);
            //Add or edit product in inventory
            if (exist == null)
            {
                exist = new Domain.Entities.Inventory
                {
                    IdSaleUser = request.IdSaleUser,
                    IdProduct = request.IdProduct,
                    InitalCantity = request.InitialCantity,
                };
                await db.Inventory.AddAsync(exist);
            }
            else
                exist.InitalCantity = request.InitialCantity;

            await db.SaveChangesAsync(cancellationToken);

            return new AddProductToInventoryResponse { };
        }
    }
}
