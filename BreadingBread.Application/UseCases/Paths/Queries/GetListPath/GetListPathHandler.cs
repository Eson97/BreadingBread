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

namespace BreadingBread.Application.UseCases.Paths.Queries.GetListPath
{
    public class GetListPathHandler : IRequestHandler<GetListPathQuery, GetListPathResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetListPathHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetListPathResponse> Handle(GetListPathQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Path.Where(el => !el.IsDeleted).Select(el => new PathLookupModel
            {
                Id = el.Id,
                Name = el.Name,
                Selected = el.Selected

            }).OrderBy(el => el.Name).ToListAsync(cancellationToken);

            return new GetListPathResponse { Paths = entity };
        }
    }
}
