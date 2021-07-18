using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathHandler : IRequestHandler<GetListStoresByPathQuery, GetListStoresByPathResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetListStoresByPathHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetListStoresByPathResponse> Handle(GetListStoresByPathQuery request, CancellationToken cancellationToken)
        {
            //Obtiene la lista de tiendas por ruta donde ni la tienda ni la ruta no estan eliminadas
            var stores = await (from ps in db.PathStore
                                join s in db.Store
                                on ps.IdStore equals s.Id
                                where !ps.IsDeleted && !s.IsDeleted
                                 && ps.IdPath == request.IdPath
                                select new StoreModelByPathId
                                {
                                    Id = s.Id,
                                    Name = s.Name
                                }).OrderBy(el => el.Name)
                               .ToListAsync(cancellationToken);

            return new GetListStoresByPathResponse { Stores = stores };
        }
    }
}
