using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Commands.AddProductToInventory
{
    public class AddProductToInventoryAuth : IAuthenticatedRequest<AddProductToInventoryCommand, AddProductToInventoryResponse>
    {
        public AddProductToInventoryAuth()
        {
        }

        public Task Validate(AddProductToInventoryCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
