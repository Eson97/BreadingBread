using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using BreadingBread.Common;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleValidator : AbstractValidator<AddSaleCommand>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IDateTime date;
        private readonly IUserAccessor currentUser;

        public AddSaleValidator(IBreadingBreadDbContext db, IDateTime date, IUserAccessor currentUser)
        {
            RuleFor(el => el.IdStore).GreaterThan(0);
            RuleFor(el => el.IdPath).GreaterThan(0);
            RuleFor(el => el.Lat).NotEmpty();
            RuleFor(el => el.Lon).NotEmpty();
            RuleFor(el => el.Total).GreaterThanOrEqualTo(0);
            RuleFor(el => el.Products).NotEmpty().When(el => el.Commentary == null);
            RuleFor(el => el.Commentary).Empty().When(el => el.Products.Count > 0);

            this.db = db;
            this.date = date;
            this.currentUser = currentUser;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<AddSaleCommand> context, CancellationToken cancellation = default)
        {
            var result = new ValidationResult();
            var request = context.InstanceToValidate;

            var userSale = await db.UserSale
                .FirstOrDefaultAsync(us => !us.Visited && us.IdUser == currentUser.UserId && us.IdPath == request.IdPath);

            if (userSale == null)
                result.Errors.Add(new ValidationFailure(nameof(request.IdPath), "La ruta ya fue cerrada por el administrador, ya no puedes realizar la venta"));

            var storeVisited = userSale.Sales
                .Where(el => el.IdStore == request.IdStore
                && el.Visited.Date == date.Now.Date)
                .FirstOrDefault();

            //Si la tienda en esa ruta ya fue visitada en ese mismo dia 
            if (storeVisited != null)
                result.Errors.Add(new ValidationFailure(nameof(request.IdStore), "Ya fue realizada una venta en esta ruta"));

            return result;
        }
    }
}
