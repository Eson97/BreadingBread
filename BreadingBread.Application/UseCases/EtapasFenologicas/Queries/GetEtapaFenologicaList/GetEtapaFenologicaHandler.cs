using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static BreadingBread.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList.GetEtapaFenologicaListResponse;

namespace BreadingBread.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList
{
    public class GetEtapaFenologicaHandler : IRequestHandler<GetEtapaFenologicaListQuery, GetEtapaFenologicaListResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetEtapaFenologicaHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetEtapaFenologicaListResponse> Handle(GetEtapaFenologicaListQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.EtapaFenologica.Where(el => !el.IsDeleted).Select(el => new EtapaLookUpModel
            {
                Id = el.Id,
                Nombre = el.Nombre,
            }).OrderBy(el => el.Nombre).ToListAsync(cancellationToken);

            return new GetEtapaFenologicaListResponse { EtapaFenologica = entity };
        }
    }
}
