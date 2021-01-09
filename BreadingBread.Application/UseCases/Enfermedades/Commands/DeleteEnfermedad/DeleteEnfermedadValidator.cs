using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadValidator : AbstractValidator<DeleteEnfermedadCommand>
    {
        private readonly IBreadingBreadDbContext db;

        public DeleteEnfermedadValidator(IBreadingBreadDbContext db)
        {
            RuleFor(el => el.IdEnferemedad).NotEmpty().GreaterThanOrEqualTo(0);
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteEnfermedadCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();

            var entity = await db
                .Enfermedad
                .SingleOrDefaultAsync(el => el.Id == request.IdEnferemedad);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Enfermedad), request.IdEnferemedad);
            }

            return result;
        }
    }
}
