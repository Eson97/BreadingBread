using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class Path : DeleteableEntity
    {
        public Path()
        {
            Stores = new HashSet<Store>();
        }

        public string Name { get; set; }
        public bool Selected { get; set; }


        public int IdUser { get; set; }
        public virtual User CurrentUser { get; set; }
        public virtual ICollection<Store> Stores { get; set; }
    }
}
