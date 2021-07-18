using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using BreadingBread.Common;
using FluentValidation.Results;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleValidator : AbstractValidator<AddSaleCommand>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IDateTime date;

        public AddSaleValidator(IBreadingBreadDbContext db, IDateTime date)
        {
            RuleFor(el => el.IdStore).GreaterThan(0);
            RuleFor(el => el.IdUserSale).GreaterThan(0);
            RuleFor(el => el.Lat).NotEmpty();
            RuleFor(el => el.Lon).NotEmpty();
            RuleFor(el => el.Total).GreaterThanOrEqualTo(0);
            this.db = db;
            this.date = date;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddSaleCommand> context, CancellationToken cancellation = default)
        {
            var result = new ValidationResult();
            var request = context.InstanceToValidate;

            var userSale = await db.UserSale.FindAsync(context);
            if (userSale == null)
                throw new NotFoundException(nameof(UserSale), request.IdUserSale);

            var storeVisited = userSale.Sales
                .Where(el => el.IdStore == request.IdStore
                && el.Visited.Date == date.Now.Date)
                .FirstOrDefault();

            //Si la tienda en esa ruta ya fue visitada en ese mismo dia 
            if (storeVisited != null)
            {
                result.Errors.Add(new ValidationFailure(nameof(request.IdStore), "La tienda en esta ruta ya fue visitada el dia de hoy"));
            }

            return result;
        }
    }
}
