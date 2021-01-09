using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.ModificarEmail
{
    public class ModificarEmailHandler : IRequestHandler<ModificarEmailCommand, ModificarEmailResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public ModificarEmailHandler(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<ModificarEmailResponse> Handle(ModificarEmailCommand request, CancellationToken cancellationToken)
        {
            var entity = await db
                .Usuario
                .SingleOrDefaultAsync(el => el.Id == currentUser.UserId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Usuario), currentUser.UserId);
            }

            if (PasswordStorage.VerifyPassword(request.Password, entity.HashedPassword))
            {
                entity.Email = request.NuevoEmail;
                entity.NormalizedEmail = request.NuevoEmail.ToUpper();

                await db.SaveChangesAsync(cancellationToken);

                return new ModificarEmailResponse
                {
                    Email = entity.Email
                };
            }
            else
            {
                throw new BadRequestException("La contrase�a es Incorrecta");
            }
        }
    }
}