using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class Product : DeleteableEntity
    {
        public Product()
        {
            SaleProducts = new HashSet<ProductSale>();
            Promotions = new HashSet<Promotion>();
            Inventory = new HashSet<Inventory>();
        }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ProductSale> SaleProducts { get; set; }
        public virtual ICollection<Promotion> Promotions { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}
