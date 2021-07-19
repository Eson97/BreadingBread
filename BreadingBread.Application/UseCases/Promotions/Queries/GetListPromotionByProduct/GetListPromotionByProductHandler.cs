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

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotionByProduct
{
    public class GetListPromotionByProductHandler : IRequestHandler<GetListPromotionByProductQuery, GetListPromotionByProductResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetListPromotionByProductHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetListPromotionByProductResponse> Handle(GetListPromotionByProductQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Promotion
                .Where(el => !el.IsDeleted && el.Active)
                .Select(el => new PromotionModelByProduct
                {
                    IdPromo = el.Id,
                    CantitySaleMin = el.CantitySaleMin,
                    SaleMin = el.SaleMin,
                    CantityFree = el.CantityFree,
                    Discount = el.Discount
                })
                //.OrderBy(el => (el.Discount > 0) ? el.Discount : el.CantityFree) //no se si esto funcione
                .ToListAsync(cancellationToken);

            return new GetListPromotionByProductResponse { Promotions = entity };
        }
    }
}
