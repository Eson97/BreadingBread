using System;

namespace BreadingBread.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int IdUserSale { get; set; }
        public int IdStore { get; set; }
        public DateTime Visited { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public decimal Total { get; set; }
        public string Commentary { get; set; }
        public virtual Store StoreVisited { get; set; }
        public virtual UserSale UserSale { get; set; }
    }
}
