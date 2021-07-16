namespace BreadingBread.Domain.Entities
{
    public class ProductSale : BaseEntity
    {
        public ProductSale()
        {
        }
        public int? IdPromo { get; set; }
        public int IdProduct { get; set; }
        public int Cantity { get; set; }
        public int PromoCantity { get; set; }
        public int ReturnCantity { get; set; }
        public decimal Discount { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual Product Product { get; set; }
    }
}
