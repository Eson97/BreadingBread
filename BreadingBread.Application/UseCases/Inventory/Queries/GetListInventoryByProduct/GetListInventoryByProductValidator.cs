using FluentValidation;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetListInventoryByProduct
{
    public class GetListInventoryByProductValidator : AbstractValidator<GetListInventoryByProductQuery>
    {
        public GetListInventoryByProductValidator()
        {
            RuleFor(el => el.IdProduct).NotEmpty();
            RuleFor(el => el.IdSaleUser).NotEmpty();
        }
    }
}
