using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Promotions.Commands.AddPromotion
{
    public class AddPromotionValidator : AbstractValidator<AddPromotionCommand>
    {
        public AddPromotionValidator()
        {
            RuleFor(el => el.IdProducto).NotEmpty();
            RuleFor(el => el.CantitySaleMin).GreaterThanOrEqualTo(0);
            RuleFor(el => el.SaleMin).GreaterThanOrEqualTo(0);
            RuleFor(el => el.CantityFree).GreaterThanOrEqualTo(0);
            RuleFor(el => el.Discount).GreaterThanOrEqualTo(0);
        }
    }
}
