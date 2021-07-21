using BreadingBread.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Commands.AddProductToInventory
{
    public class AddProductToInventoryValidator : AbstractValidator<AddProductToInventoryCommand>
    {
        private readonly IBreadingBreadDbContext db;

        public AddProductToInventoryValidator(IBreadingBreadDbContext db)
        {
            RuleFor(el => el.IdProduct).NotEmpty();
            RuleFor(el => el.IdSaleUser).NotEmpty();
            RuleFor(el => el.InitialCantity).NotEmpty().GreaterThanOrEqualTo(0);
            this.db = db;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddProductToInventoryCommand> context, CancellationToken cancellation = default)
        {
            var result = new ValidationResult();
            var request = context.InstanceToValidate;
            var product = await db.Product.AnyAsync(el => el.Id == request.IdProduct, cancellation);
            if (!product)
                result.Errors.Add(new ValidationFailure(nameof(request.IdSaleUser), "El producto que intenta vender no existe"));

            var userSale = await db.UserSale.AnyAsync(el => el.Id == request.IdSaleUser, cancellation);
            if (!userSale)
                result.Errors.Add(new ValidationFailure(nameof(request.IdSaleUser), "Aun no se selecciona una ruta para vender"));

            return result;
        }
    }
}
