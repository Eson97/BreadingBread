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

namespace BreadingBread.Application.UseCases.Products.Queries.GetListProducts
{
    public class GetListProductsHandler : IRequestHandler<GetListProductsQuery, GetListProductsResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetListProductsHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetListProductsResponse> Handle(GetListProductsQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Product
                .Where(el => !el.IsDeleted)
                .Select(el => new ProductModel
                {
                    Id = el.Id,
                    Name = el.Name,
                    Price = el.Price

                }).OrderBy(el => el.Name)
            .ToListAsync(cancellationToken);

            return new GetListProductsResponse { Products = entity };
        }
    }
}
