using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario
{
    public class ModificarDatosUsuarioHandler : IRequestHandler<ModificarDatosUsuarioCommand, ModificarDatosUsuarioResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public ModificarDatosUsuarioHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<ModificarDatosUsuarioResponse> Handle(ModificarDatosUsuarioCommand request, CancellationToken cancellationToken)
        {
            User entity = await db.User.FindAsync(request.IdUsuario);
            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.IdUsuario);
            }

            entity.Name = request.Name;

            await db.SaveChangesAsync(cancellationToken);

            return new ModificarDatosUsuarioResponse
            {
                IdUsuario = entity.Id,
                Nombre = entity.Name
            };
        }
    }
}