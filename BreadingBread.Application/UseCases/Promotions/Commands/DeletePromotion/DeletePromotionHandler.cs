using BreadingBread.Application.Exceptions;
using BreadingBread.Application.Interfaces;
using BreadingBread.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Promotions.Commands.DeletePromotion
{
    public class DeletePromotionHandler : IRequestHandler<DeletePromotionCommand, DeletePromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public DeletePromotionHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<DeletePromotionResponse> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionToDelete = await db.Promotion.FindAsync(request.Id);

            if (promotionToDelete == null)
                throw new NotFoundException(nameof(Promotion), request.Id);

            db.Promotion.Remove(promotionToDelete);
            await db.SaveChangesAsync(cancellationToken);

            return new DeletePromotionResponse();
        }
    }
}
