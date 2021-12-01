using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleHandler : IRequestHandler<AddSaleCommand, AddSaleResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;
        private readonly IDateTime dateTime;

        public AddSaleHandler(IBreadingBreadDbContext db, IUserAccessor currentUser, IDateTime dateTime)
        {
            this.db = db;
            this.currentUser = currentUser;
            this.dateTime = dateTime;
        }

        public async Task<AddSaleResponse> Handle(AddSaleCommand request, CancellationToken cancellationToken)
        {
            var userSale = await
                db.UserSale
                .Where(el => el.IdUser == currentUser.UserId && !el.Visited)
                .FirstOrDefaultAsync();

            if (userSale == null)
                throw new NotFoundException(nameof(UserSale), request.IdPath);

            var store = await db.Store.FindAsync(request.IdStore);
            if (store == null)
                throw new NotFoundException(nameof(Store), request.IdStore);

            var pathStore = await db.PathStore.FirstOrDefaultAsync(p => p.IdPath == request.IdPath && p.IdStore == request.IdStore);
            if (pathStore == null)
                throw new BadRequestException("La tienda no se encuentra en esta ruta");

            int idSale = await db.Sale
                    .Where(sale => sale.IdUserSale == userSale.Id && sale.IdStore == request.IdStore)
                    .Select(sale => sale.Id)
                    .FirstOrDefaultAsync();

            if (idSale > 0)
                return new AddSaleResponse { IdSale = idSale };

            var sale = new Domain.Entities.Sale
            {
                IdUserSale = userSale.Id,
                IdStore = request.IdStore,
                Commentary = request.Commentary ?? "",
                Lat = request.Lat,
                Lon = request.Lon,
                Total = request.Total,
                Visited = dateTime.Now
            };

            await db.Sale.AddAsync(sale, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);

            foreach (var productRequest in request.Products)
            {
                var product = await db.Product.FindAsync(productRequest.IdProduct);
                if (product == null)
                    throw new NotFoundException(nameof(Product), productRequest.IdProduct);

                var saleProduct = new ProductSale
                {
                    IdSale = sale.Id,
                    IdProduct = productRequest.IdProduct,
                    UnitPrice = productRequest.UnitPrice,
                    Cantity = productRequest.Cantity,
                    Total = productRequest.Total,

                    IdPromo = productRequest.IdPromo,
                    Discount = productRequest.Discount ?? 0,
                    PromoCantity = productRequest.PromoCantity ?? 0,
                    ReturnCantity = productRequest.ReturnCantity ?? 0,
                };

                await db.ProductSale.AddAsync(saleProduct, cancellationToken);
            }
            await db.SaveChangesAsync(cancellationToken);

            return new AddSaleResponse { IdSale = sale.Id };
        }
    }
}
