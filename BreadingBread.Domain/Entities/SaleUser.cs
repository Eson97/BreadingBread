using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class SaleUser : BaseEntity
    {
        public SaleUser()
        {
            SaleProducts = new HashSet<SaleProduct>();
        }

        public decimal Total { get; set; }
        public decimal Wastage { get; set; }


        public int IdUser { get; set; }
        public int IdStore { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual ReasonSale Reason { get; set; }
        public virtual ICollection<SaleProduct> SaleProducts { get; set; }
    }
}
