using FluentValidation;

namespace BreadingBread.Application.UseCases.Inventory.Commands.DeleteProductoFromInventory
{
    public class DeleteProductoFromInventoryValidator : AbstractValidator<DeleteProductoFromInventoryCommand>
    {
        public DeleteProductoFromInventoryValidator()
        {
            RuleFor(el => el.Id).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
