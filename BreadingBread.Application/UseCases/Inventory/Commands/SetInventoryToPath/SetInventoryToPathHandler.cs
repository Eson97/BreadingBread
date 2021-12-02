using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BreadingBread.Domain.Entities;


namespace BreadingBread.Application.UseCases.Inventory.Commands.SetInventoryToPath
{
    public class SetInventoryToPathHandler : IRequestHandler<SetInventoryToPathCommand, SetInventoryToPathResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public SetInventoryToPathHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<SetInventoryToPathResponse> Handle(SetInventoryToPathCommand request, CancellationToken cancellationToken)
        {
            //Validamos que la ruta exista
            var userSale = await db.UserSale.AnyAsync(el => el.Id == request.IdSaleUser, cancellationToken);
            if (!userSale)
                throw new NotFoundException(nameof(UserSale), request.IdSaleUser);

            //Eliminamos los Productos con cantidad igual a 0
            var newInventory = request.Inventory
                .Where(el => el.Quantity > 0)
                .Select(el => new ProductModel
                {
                    IdProduct = el.IdProduct,
                    Quantity = el.Quantity
                })
                .OrderBy(el => el.IdProduct).ToList();

            //Verificamos que los productos existan
            newInventory.ToList().ForEach(async item =>
            {
                var product = await (db.Product.AnyAsync(el => el.Id == item.IdProduct, cancellationToken));
                if (!product)
                    throw new NotFoundException(nameof(Product), item.IdProduct);
            });

            //creamos la lista para enviarla a la db
            var finalInventory = newInventory
                .Select(el => new Domain.Entities.Inventory
                {
                    IdSaleUser = request.IdSaleUser,
                    IdProduct = el.IdProduct,
                    InitalCantity = el.Quantity
                })
                .OrderBy(el => el.IdProduct).ToList();

            //agregamos a la db
            await db.Inventory.AddRangeAsync(finalInventory);
            await db.SaveChangesAsync(cancellationToken);

            return new SetInventoryToPathResponse { };
        }
    }
}
