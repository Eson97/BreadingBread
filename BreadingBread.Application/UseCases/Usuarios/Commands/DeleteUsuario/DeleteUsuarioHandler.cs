using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, DeleteUsuarioResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeleteUsuarioHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeleteUsuarioResponse> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            var user = await db
                        .User
                        .SingleOrDefaultAsync(el => el.UserName == request.UserName);
            if (user != null)
            {
                var tokens = await db.UserToken.Where(el => el.IdUser == user.Id).ToListAsync();
                db.UserToken.RemoveRange(tokens);
                db.User.Remove(user);
                await db.SaveChangesAsync(cancellationToken);
            }

            return new DeleteUsuarioResponse();
        }
    }
}
