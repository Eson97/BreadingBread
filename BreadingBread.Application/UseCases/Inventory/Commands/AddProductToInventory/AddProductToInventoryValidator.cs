using FluentValidation;

namespace BreadingBread.Application.UseCases.Inventory.Commands.AddProductToInventory
{
    public class AddProductToInventoryValidator : AbstractValidator<AddProductToInventoryCommand>
    {
        public AddProductToInventoryValidator()
        {
            RuleFor(el => el.IdProduct).NotEmpty();
            RuleFor(el => el.IdSaleUser).NotEmpty();
            RuleFor(el => el.InitialCantity).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
