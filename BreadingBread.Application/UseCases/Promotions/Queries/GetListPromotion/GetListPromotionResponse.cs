using System;
using System.Collections.Generic;
using System.Text;

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotion
{
    public class GetListPromotionResponse
    {
        public IList<PromotionModel> Promotions { get; set; }
    }

    public class PromotionModel
    {
        public int IdPromo { get; set; }
        public int IdProducto { get; set; }
        public int CantitySaleMin { get; set; }
        public decimal SaleMin { get; set; }
        public int CantityFree { get; set; }
        public int Discount { get; set; }
    }
}
