using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class Product : DeleteableEntity
    {
        public Product()
        {
            SaleProducts = new HashSet<SaleProduct>();
        }
        public string Name { get; set; }
        public decimal Prize { get; set; }

        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
