using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.SaleProduct.Commands.AddProductSale
{
    public class AddProductSaleValidator : AbstractValidator<AddProductSaleCommand>
    {
        private readonly IBreadingBreadDbContext db;

        public AddProductSaleValidator(IBreadingBreadDbContext db)
        {
            this.db = db;

            RuleFor(el => el.IdProduct).GreaterThan(0);
            RuleFor(el => el.Total).GreaterThan(0);
            RuleFor(el => el.Cantity).GreaterThan(0);
            RuleFor(el => el.UnitPrice).GreaterThan(0);

            RuleFor(el => el.IdPromo)
                .Must(el => el.Value > 0)
                .When(el => el.IdPromo.HasValue);

            RuleFor(el => el.PromoCantity)
                .Must(el => el.Value > 0)
                .When(el => el.PromoCantity.HasValue);

            RuleFor(el => el.ReturnCantity)
                .Must(el => el.Value > 0)
                .When(el => el.ReturnCantity.HasValue);

            RuleFor(el => el.Discount)
                .Must(el => el.Value > 0)
                .When(el => el.Discount.HasValue);
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddProductSaleCommand> context, CancellationToken cancellation = default)
        {
            var result = new ValidationResult();
            var request = context.InstanceToValidate;

            var product = await db.Product.FindAsync(request.IdProduct);
            if (product == null)
                throw new NotFoundException(nameof(product), request.IdProduct);

            var promo = await db.Promotion.FindAsync(request.IdPromo ?? 0);

            if (promo != null && !promo.Active)
                result.Errors.Add(new ValidationFailure(nameof(request.IdPromo),
                    $"La promocion {promo.Id} no esta activa, no la aplique"));

            //Si la tienda en esa ruta ya fue visitada en ese mismo dia 
            if (promo != null && promo.IdProducto != request.IdProduct)
                result.Errors.Add(new ValidationFailure(nameof(request.IdPromo),
                    $"La promocion {promo.Id} no se puede aplicar al producto {product.Name}"));

            return result;
        }
    }
}
