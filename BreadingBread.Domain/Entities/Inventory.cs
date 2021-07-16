namespace BreadingBread.Domain.Entities
{
    public class Inventory : BaseEntity
    {
        public int IdSaleUser { get; set; }
        public int IdProduct { get; set; }
        public int InitalCantity { get; set; }
        public virtual Product Product { get; set; }
        public virtual UserSale UserSale { get; set; }

    }
}
