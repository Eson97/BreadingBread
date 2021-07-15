using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class SaleProduct : BaseEntity
    {
        public SaleProduct()
        {
        }
        public int Cantity { get; set; }
        public decimal Price { get; set; }

        public int IdSaleUser { get; set; }
        public int IdProduct { get; set; }
        public virtual SaleUser SaleUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
