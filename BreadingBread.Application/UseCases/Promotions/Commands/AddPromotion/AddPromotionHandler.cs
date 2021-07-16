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

namespace BreadingBread.Application.UseCases.Promotions.Commands.AddPromotion
{
    public class AddPromotionHandler : IRequestHandler<AddPromotionCommand, AddPromotionResponse>
    {
        private readonly IBreadingBreadDbContext db;

        public AddPromotionHandler(IBreadingBreadDbContext db)
        {
            this.db = db;
        }

        public async Task<AddPromotionResponse> Handle(AddPromotionCommand request, CancellationToken cancellationToken)
        {
            var productExist = await db.Product.AnyAsync(el => el.Id == request.IdProducto);

            if (!productExist)
                throw new NotFoundException(nameof(Product), request.IdProducto);

            var newPromotion = new Promotion
            {
                IdProducto = request.IdProducto,
                CantitySaleMin = request.CantitySaleMin,
                SaleMin = request.SaleMin,
                CantityFree = request.CantityFree,
                Discount = request.Discount,
                Active = true
            };

            db.Promotion.Add(newPromotion);
            await db.SaveChangesAsync(cancellationToken);

            return new AddPromotionResponse();
        }
    }
}
