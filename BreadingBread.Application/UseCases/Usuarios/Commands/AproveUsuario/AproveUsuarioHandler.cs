using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioHandler : IRequestHandler<AproveUsuarioCommand, AproveUsuarioResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AproveUsuarioHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AproveUsuarioResponse> Handle(AproveUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = await db
                        .User
                        .SingleOrDefaultAsync(el => el.UserName == request.UserName);
            if (user != null)
            {
                db.User.Attach(user);
                user.Aproved = true;
                await db.SaveChangesAsync(cancellationToken);
            }
            return new AproveUsuarioResponse();
        }
    }
}
