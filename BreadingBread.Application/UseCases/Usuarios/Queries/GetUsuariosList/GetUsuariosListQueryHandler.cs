using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListQueryHandler : IRequestHandler<GetUsuariosListQuery, GetUsuariosListResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetUsuariosListQueryHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetUsuariosListResponse> Handle(GetUsuariosListQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await db
                .User
                .Select(el => new UsuarioLookupModel
                {
                    Id = el.Id,
                    UserName = el.UserName,
                    Name = el.Name,
                    UserType = el.UserType,
                    Aproved = el.Aproved,
                })
                .OrderBy(el => el.Aproved)
                .ToListAsync(cancellationToken);

            return new GetUsuariosListResponse { Usuarios = usuarios };
        }
    }
}