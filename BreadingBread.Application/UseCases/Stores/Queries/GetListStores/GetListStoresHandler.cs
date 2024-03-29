using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStores
{
    public class GetListStoresHandler : IRequestHandler<GetListStoresQuery, GetListStoresResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetListStoresHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetListStoresResponse> Handle(GetListStoresQuery request, CancellationToken cancellationToken)
        {
            var allStores = await db.Store
                .Where(el => !el.IsDeleted)
                .Select(el => new StoreModel
                {
                    Id = el.Id,
                    Name = el.Name

                }).OrderBy(el => el.Name)
            .ToListAsync(cancellationToken);

            return new GetListStoresResponse { Stores = allStores };
        }
    }
}
