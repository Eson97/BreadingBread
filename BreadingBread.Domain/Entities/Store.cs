using System.Collections.Generic;

namespace BreadingBread.Domain.Entities
{
    public class Store : DeleteableEntity
    {
        public Store()
        {
            Paths = new HashSet<PathStore>();
        }

        public string Name { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }

        public virtual ICollection<PathStore> Paths { get; set; }
    }
}
