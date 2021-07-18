using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Commands.DeleteProductoFromInventory
{
    public class DeleteProductoFromInventoryAuth : IAuthenticatedRequest<DeleteProductoFromInventoryCommand, DeleteProductoFromInventoryResponse>
    {
        public DeleteProductoFromInventoryAuth()
        {
        }

        public Task Validate(DeleteProductoFromInventoryCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
