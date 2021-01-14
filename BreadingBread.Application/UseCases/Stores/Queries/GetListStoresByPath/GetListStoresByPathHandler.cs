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
            var entity = await db.Store.Where(el => !el.IsDeleted && el.IdPath == request.IdPath).Select(el => new StoreModelByPathId
            {
                Id = el.Id,
                Name = el.Name

            }).OrderBy(el => el.Name).ToListAsync(cancellationToken);

            return new GetListStoresByPathResponse { Stores = entity };
        }
    }
}
