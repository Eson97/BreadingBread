using System;
using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class UserSale : BaseEntity
    {
        public UserSale()
        {
            Sales = new HashSet<Sale>();
        }

        public int IdUser { get; set; }
        public int IdPath { get; set; }
        public DateTime Visited { get; set; }

        public virtual User User { get; set; }
        public virtual Path Path { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
