using BreadingBread.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioCommandValidator : AbstractValidator<CreateUsuarioCommand>
    {
        private readonly IBreadingBreadDbContext db;

        public CreateUsuarioCommandValidator(IBreadingBreadDbContext db)
        {
            this.db = db;
            RuleFor(el => el.UserName).Matches("^[a-zA-Z]+(?:[_-]?[a-zA-Z0-9])*$").MaximumLength(20).NotEmpty();
            RuleFor(el => el.Password).NotNull().NotEmpty();
            RuleFor(el => el.UserType).GreaterThanOrEqualTo(0);
            RuleFor(el => el.Name).MaximumLength(20).NotEmpty();
        }

        public override async Task<FluentValidation.Results.ValidationResult> ValidateAsync(ValidationContext<CreateUsuarioCommand> context, CancellationToken cancellation = default)
        {
            var result = new FluentValidation.Results.ValidationResult();
            var entity = context.InstanceToValidate;

            string normalizedUser = entity.UserName.ToUpper();

            bool nombreUsuarioRegistrado = await db
                .User
                .AnyAsync(el => el.NormalizedUserName == normalizedUser, cancellation);


            if (nombreUsuarioRegistrado)
            {
                result.Errors.Add(new ValidationFailure(nameof(entity.UserName), "El nombre de usuario ya se encuentra registrado"));
            }

            return result;
        }
    }
}