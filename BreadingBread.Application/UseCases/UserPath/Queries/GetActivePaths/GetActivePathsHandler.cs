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

namespace BreadingBread.Application.UseCases.UserPath.Queries.GetActivePaths
{
    public class GetActivePathsHandler : IRequestHandler<GetActivePathsQuery, GetActivePathsResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetActivePathsHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetActivePathsResponse> Handle(GetActivePathsQuery request, CancellationToken cancellationToken)
        {
            var activePathsWithoutInventory = await (from userSale in db.UserSale
                                where userSale.Visited == false
                                join inventory in db.Inventory on userSale.Id equals inventory.IdSaleUser into nt
                                from z in nt.DefaultIfEmpty()
                                where z == null
                                select new ActivePathsModel
                                {
                                    Id = userSale.Id,
                                    Name = userSale.Path.Name
                                }
                                ).ToListAsync(cancellationToken);


            return new GetActivePathsResponse { ActivePaths = activePathsWithoutInventory };
        }
    }
}
