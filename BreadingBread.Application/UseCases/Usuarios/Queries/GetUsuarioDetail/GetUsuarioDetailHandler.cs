using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioDetail
{
    public class GetUsuarioDetailHandler : IRequestHandler<GetUsuarioDetailQuery, GetUsuarioDetailResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetUsuarioDetailHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetUsuarioDetailResponse> Handle(GetUsuarioDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.User.FindAsync(request.IdUsuario);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.IdUsuario);
            }

            return new GetUsuarioDetailResponse
            {
                TipoUsuario = entity.UserType,
                IdUsuario = entity.Id,
                NombreUsuario = entity.UserName,
                Nombre = entity.Name,
            };
        }
    }
}