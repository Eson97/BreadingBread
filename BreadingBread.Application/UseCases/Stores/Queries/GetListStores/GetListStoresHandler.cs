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
        private readonly IUserAccessor currentUser;

        public GetListStoresHandler(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task<GetListStoresResponse> Handle(GetListStoresQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Store
                .Where(el => !el.IsDeleted && el.Path.IdUser == currentUser.UserId)
                .Select(el => new StoreModel
                {
                    Id = el.Id,
                    Name = el.Name

                }).OrderBy(el => el.Name)
            .ToListAsync(cancellationToken);

            return new GetListStoresResponse { Stores = entity };
        }
    }
}
