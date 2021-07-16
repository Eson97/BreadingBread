namespace BreadingBread.Domain.Entities
{
    public class Promotion : DeleteableEntity
    {
        public int IdProducto { get; set; }
        public int CantitySaleMin { get; set; }
        public decimal SaleMin { get; set; }
        public int CantityFree { get; set; }
        public int Discount { get; set; }
        public bool Active { get; set; }

        public virtual Product Product { get; set; }
    }
}
