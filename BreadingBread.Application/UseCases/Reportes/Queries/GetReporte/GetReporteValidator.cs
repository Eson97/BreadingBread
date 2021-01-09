using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Reportes.Queries.GetReporte
{
    public class GetReporteValidator : AbstractValidator<GetReporteQuery>
    {
        private readonly IBreadingBreadDbContext db;

        public GetReporteValidator(IBreadingBreadDbContext db)
        {
            RuleFor(el => el.IdReporte).GreaterThan(0).NotEmpty();
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetReporteQuery> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();
            var entity = await db
                .Reporte
                .SingleOrDefaultAsync(el => el.Id == request.IdReporte);

            //If Single Report exist, get all
            if (entity == null)
            {
                throw new NotFoundException(nameof(Reporte), request.IdReporte);
            }
            return result;

        }
    }
}