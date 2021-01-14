using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class Store : DeleteableEntity
    {
        public Store()
        {
            Sales = new HashSet<SaleUser>();
        }

        public string Name { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }


        public int IdPath { get; set; }
        public virtual Path Path { get; set; }
        public virtual ICollection<SaleUser> Sales { get; set; }
    }
}
