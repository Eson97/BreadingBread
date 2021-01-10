using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUsuarioLoginQueryValidator : AbstractValidator<GetUsuarioLoginQuery>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IDateTime dateTime;

        public GetUsuarioLoginQueryValidator(IBreadingBreadDbContext db, IDateTime dateTime)
        {
            RuleFor(el => el.UserName).NotEmpty();
            RuleFor(el => el.Password).NotEmpty();
            this.db = db;
            this.dateTime = dateTime;
        }

        public override async Task<ValidationResult> ValidateAsync(ValidationContext<GetUsuarioLoginQuery> context, CancellationToken cancellation = default)
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

            // Comprobar el tiempo para desbloquear la cuenta
            if (entity.LockoutEnd > dateTime.Now)
            {
                int minutosRestantes = (entity.LockoutEnd - dateTime.Now).Minutes + 1;
                throw new ForbiddenException($"Sobrepasaste la cantidad de intentos de inicio de sesion, espera {minutosRestantes} minutos");
            }

            return result;
        }
    }
}