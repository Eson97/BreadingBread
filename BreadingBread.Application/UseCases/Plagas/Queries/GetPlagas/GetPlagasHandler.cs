using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Plagas.Queries.GetPlagas
{
    public class GetPlagasHandler : IRequestHandler<GetPlagasQuery, GetPlagasResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetPlagasHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetPlagasResponse> Handle(GetPlagasQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Plaga.Where(el => !el.IsDeleted).Select(el => new PlagaLookupModel
            {
                Id = el.Id,
                Nombre = el.Nombre,
            }).OrderBy(el => el.Nombre).ToListAsync(cancellationToken);

            return new GetPlagasResponse { Plagas = entity };
        }
    }
}
