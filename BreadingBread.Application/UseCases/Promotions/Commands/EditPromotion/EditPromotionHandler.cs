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

namespace BreadingBread.Application.UseCases.Promotions.Commands.EditPromotion
{
    public class EditPromotionHandler : IRequestHandler<EditPromotionCommand, EditPromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public EditPromotionHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<EditPromotionResponse> Handle(EditPromotionCommand request, CancellationToken cancellationToken)
        {
            var promotionToEdit = await db.Promotion.FindAsync(request.Id);

            if (promotionToEdit == null)
                throw new NotFoundException(nameof(Promotion), request.Id);

            promotionToEdit.IdProducto = request.IdProducto;
            promotionToEdit.CantitySaleMin = request.CantitySaleMin;
            promotionToEdit.SaleMin = request.SaleMin;
            promotionToEdit.CantityFree = request.CantityFree;
            promotionToEdit.Discount = request.Discount;
            promotionToEdit.Active = request.Active;


            await db.SaveChangesAsync(cancellationToken);

            return new EditPromotionResponse();
        }
    }
}
