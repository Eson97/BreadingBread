using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class Path : DeleteableEntity
    {
        public Path()
        {
            UserSales = new HashSet<UserSale>();
            PathStores = new HashSet<PathStore>();
        }

        public string Name { get; set; }
        public bool Selected { get; set; }


        public int? IdUser { get; set; }
        public virtual User CurrentUser { get; set; }
        public virtual ICollection<UserSale> UserSales { get; set; }
        public virtual ICollection<PathStore> PathStores { get; set; }
    }
}
