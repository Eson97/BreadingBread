using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.RefreshCredentials
{
    public class RefreshCredentialsHandler : IRequestHandler<RefreshCredentialsCommand, RefreshCredentialsResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IRandomGenerator randomGenerator;

        public RefreshCredentialsHandler(IBreadingBreadDbContext db, IRandomGenerator randomGenerator)
        {
            this.db = db;
            this.randomGenerator = randomGenerator;
        }

        public async Task<RefreshCredentialsResponse> Handle(RefreshCredentialsCommand request, CancellationToken cancellationToken)
        {
            var token = await db
                .UserToken
                .Include(el => el.UserNavigation)
                .SingleOrDefaultAsync(el => el.RefreshToken == request.RefreshToken);

            if (token == null)
            {
                throw new NotAuthorizedException("No se puede comprobar tu informacion");
            }

            string randomToken = randomGenerator.SecureRandomString(32);
            token.RefreshToken = randomToken;
            await db.SaveChangesAsync(cancellationToken);

            return new RefreshCredentialsResponse
            {
                IdUsuario = token.IdUser,
                UserName = token.UserNavigation.UserName,
                RefreshToken = token.RefreshToken,
                UserType = token.UserNavigation.UserType
            };
        }
    }
}