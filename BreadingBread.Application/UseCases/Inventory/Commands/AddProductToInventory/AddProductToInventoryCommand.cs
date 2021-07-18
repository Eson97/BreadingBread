using MediatR;

namespace BreadingBread.Application.UseCases.Inventory.Commands.AddProductToInventory
{
    public class AddProductToInventoryCommand : IRequest<AddProductToInventoryResponse>
    {
        public int IdProduct { get; set; }
        public int IdSaleUser { get; set; }
        public int InitialCantity { get; set; }
    }
}
