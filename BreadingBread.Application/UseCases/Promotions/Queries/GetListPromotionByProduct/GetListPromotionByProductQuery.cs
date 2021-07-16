using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotionByProduct
{
    public class GetListPromotionByProductQuery : IRequest<GetListPromotionByProductResponse>
    {
        public int IdProducto { get; set; }

    }
}
