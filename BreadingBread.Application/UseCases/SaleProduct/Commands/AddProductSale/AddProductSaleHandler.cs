using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.SaleProduct.Commands.AddProductSale
{
    public class AddProductSaleHandler : IRequestHandler<AddProductSaleCommand, AddProductSaleResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AddProductSaleHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AddProductSaleResponse> Handle(AddProductSaleCommand r, CancellationToken cancellationToken)
        {
            var product = await db.Product.FindAsync(r.IdProduct);
            if (product == null)
                throw new NotFoundException(nameof(Product), r.IdProduct);

            var sale = await db.Sale.FindAsync(r.IdSale);
            if (sale == null)
                throw new NotFoundException(nameof(Store), r.IdSale);

            var saleProduct = new ProductSale
            {
                IdSale = r.IdSale,
                IdProduct = r.IdProduct,
                UnitPrice = r.UnitPrice,
                Cantity = r.Cantity,
                Total = r.Total,

                IdPromo = r.IdPromo,
                Discount = r.Discount ?? 0,
                PromoCantity = r.PromoCantity ?? 0,
                ReturnCantity = r.ReturnCantity ?? 0,
            };

            await db.ProductSale.AddAsync(saleProduct, cancellationToken);
            await db.SaveChangesAsync(cancellationToken);
            return new AddProductSaleResponse();
        }
    }
}
