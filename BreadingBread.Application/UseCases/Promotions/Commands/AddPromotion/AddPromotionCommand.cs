using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Promotions.Commands.AddPromotion
{
    public class AddPromotionCommand : IRequest<AddPromotionResponse>
    {
        public int IdProducto { get; set; }
        public int CantitySaleMin { get; set; }
        public decimal SaleMin { get; set; }
        public int CantityFree { get; set; }
        public int Discount { get; set; }
    }
}
