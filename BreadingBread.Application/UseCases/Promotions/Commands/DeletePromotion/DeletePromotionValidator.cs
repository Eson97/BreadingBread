using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Promotions.Commands.DeletePromotion
{
    public class DeletePromotionValidator : AbstractValidator<DeletePromotionCommand>
    {
        public DeletePromotionValidator()
        {
            RuleFor(el => el.Id).NotEmpty();
        }
    }
}
