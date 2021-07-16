using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotionByProduct
{
    public class GetListPromotionByProductValidator : AbstractValidator<GetListPromotionByProductQuery>
    {
        public GetListPromotionByProductValidator()
        {
            RuleFor(el => el.IdProducto).NotEmpty();
        }
    }
}
