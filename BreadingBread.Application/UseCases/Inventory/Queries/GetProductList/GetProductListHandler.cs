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

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, GetProductListResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetProductListHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetProductListResponse> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Product
                .Where(el => !el.IsDeleted)
                .Select(el => new ProductModel
                {
                    Id = el.Id,
                    Name = el.Name,
                    Quantity = 0

                }).OrderBy(el => el.Name)
            .ToListAsync(cancellationToken);

            return new GetProductListResponse { Products = entity };
        }
    }
}
