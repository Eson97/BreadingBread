using MediatR;

namespace BreadingBread.Application.UseCases.Inventory.Commands.DeleteProductoFromInventory
{
    public class DeleteProductoFromInventoryCommand : IRequest<DeleteProductoFromInventoryResponse>
    {
        public int Id { get; set; }
    }
}
