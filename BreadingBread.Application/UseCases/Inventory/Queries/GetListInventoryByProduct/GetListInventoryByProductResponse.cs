using System.Collections.Generic;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetListInventoryByProduct
{
    public class GetListInventoryByProductResponse
    {
        public List<InventoryDTO> Inventory { get; set; }
    }

    public class InventoryDTO
    {
        public int IdInventory { get; set; }
        public int IdSaleUser { get; set; }
        public int IdProduct { get; set; }
        public int InitalCantity { get; set; }
    }
}
