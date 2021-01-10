using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioValidator : AbstractValidator<DeleteUsuarioCommand>
    {
        private readonly IBreadingBreadDbContext db;

        public DeleteUsuarioValidator(IBreadingBreadDbContext db)
        {
            RuleFor(el => el.UserName).Matches("^[a-zA-Z]+(?:[_-]?[a-zA-Z0-9])*$").MaximumLength(20).NotEmpty();
            this.db = db;
        }
        public override async Task<ValidationResult> ValidateAsync(ValidationContext<DeleteUsuarioCommand> context, CancellationToken cancellation = default)
        {
            var request = context.InstanceToValidate;
            var result = new ValidationResult();

            var entity = await db
                .User
                .SingleOrDefaultAsync(el => el.UserName == request.UserName);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserName);
            }

            return result;
        }
    }
}
