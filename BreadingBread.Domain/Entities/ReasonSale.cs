namespace BreadingBread.Domain.Entities
{
    public class ReasonSale : BaseEntity
    {
        public string Description { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }

        public int IdSaleUser { get; set; }
        public virtual SaleUser SaleUser { get; set; }
    }
}
