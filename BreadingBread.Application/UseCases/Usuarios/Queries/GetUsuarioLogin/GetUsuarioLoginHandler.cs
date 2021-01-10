using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using BreadingBread.Common;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUsuarioLoginHandler : IRequestHandler<GetUsuarioLoginQuery, GetUsuarioLoginResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IDateTime dateTime;
        private readonly IRandomGenerator randomGenerator;

        public GetUsuarioLoginHandler(IBreadingBreadDbContext db, IDateTime dateTime, IRandomGenerator randomGenerator)
        {
            this.db = db;
            this.dateTime = dateTime;
            this.randomGenerator = randomGenerator;
        }

        public async Task<GetUsuarioLoginResponse> Handle(GetUsuarioLoginQuery request, CancellationToken cancellationToken)
        {
            var entity = await db
                .User
                .SingleOrDefaultAsync(el => el.UserName == request.UserName);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserName);
            }

            if (PasswordStorage.VerifyPassword(request.Password, entity.HashedPassword))
            {
                if (!entity.Aproved)
                {
                    throw new ForbiddenException("La cuenta no ha sido aprobada por el administrador");
                }

                string randomToken = randomGenerator.SecureRandomString(32);

                db.UserToken.Add(new UserToken
                {
                    IdUser = entity.Id,
                    RefreshToken = randomToken
                });
                entity.AccessFailedCount = 0;

                await db.SaveChangesAsync(cancellationToken);

                return new GetUsuarioLoginResponse
                {
                    UserName = entity.UserName,
                    IdUsuario = entity.Id,
                    UserType = entity.UserType,
                    RefreshToken = randomToken
                };
            }
            else
            {
                entity.AccessFailedCount++;
                if (entity.AccessFailedCount >= 5)
                {
                    entity.LockoutEnd = dateTime.Now.AddMinutes(1);
                }
                await db.SaveChangesAsync(cancellationToken);

                throw new NotFoundException(nameof(User), request.UserName);
            }
        }
    }
}