using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordHandler : IRequestHandler<ModificarPasswordCommand, ModificarPasswordResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public ModificarPasswordHandler(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<ModificarPasswordResponse> Handle(ModificarPasswordCommand request, CancellationToken cancellationToken)
        {
            var entity = await db
                .User
                .SingleOrDefaultAsync(el => el.Id == currentUser.UserId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), currentUser.UserId);
            }

            if (PasswordStorage.VerifyPassword(request.PasswordActual, entity.HashedPassword))
            {
                string pass = PasswordStorage.CreateHash(request.PasswordNuevo);

                entity.HashedPassword = pass;

                var tokens = await db
                    .UserToken
                    .Where(el => el.IdUser == currentUser.UserId).
                    ToListAsync();

                db.UserToken.RemoveRange(tokens);

                await db.SaveChangesAsync(cancellationToken);

                return new ModificarPasswordResponse
                {
                };
            }
            else
            {
                throw new BadRequestException("La contraseña es Incorrecta");
            }
        }
    }
}