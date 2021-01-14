using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStores
{
    public class GetListStoresValidator : AbstractValidator<GetListStoresQuery>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor c;

        public GetListStoresValidator(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.c = currentUser;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetListStoresQuery> context, CancellationToken cancellation = default)
        {
            ValidationResult result = new ValidationResult();
            var request = context.InstanceToValidate;

            int pathAsignado = await db.Path
                .Where(el => el.IdUser == c.UserId)
                .Select(el => el.Id)
                .FirstOrDefaultAsync();

            if (pathAsignado <= 0)
                throw new NotFoundException(nameof(Path), c.UserId);

            return result;
        }
    }
}
