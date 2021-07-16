using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Promotions.Commands.DeletePromotion
{
    public class DeletePromotionCommand : IRequest<DeletePromotionResponse>
    {
        public int Id { get; set; }

    }
}
