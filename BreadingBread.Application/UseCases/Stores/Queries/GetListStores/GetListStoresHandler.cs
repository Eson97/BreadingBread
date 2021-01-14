using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var entity = await db.Store.Where(el => !el.IsDeleted).Select(el => new StoreModel
            {
                Id = el.Id,
                Name = el.Name

            }).OrderBy(el => el.Name).ToListAsync(cancellationToken);

            return new GetListStoresResponse { Stores = entity };
        }
    }
}
