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

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotion
{
    public class GetListPromotionHandler : IRequestHandler<GetListPromotionQuery, GetListPromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public GetListPromotionHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<GetListPromotionResponse> Handle(GetListPromotionQuery request, CancellationToken cancellationToken)
        {
            var entity = await db.Promotion
                .Where(el => !el.IsDeleted && el.Active)
                .Select(el => new PromotionModel
                {
                    IdProducto = el.IdProducto,
                    CantitySaleMin = el.CantitySaleMin,
                    SaleMin = el.SaleMin,
                    CantityFree = el.CantityFree,
                    Discount = el.Discount,
                })
                .OrderBy(el => el.IdProducto)
                .ToListAsync(cancellationToken);

            return new GetListPromotionResponse { Promotions = entity };
        }
    }
}
