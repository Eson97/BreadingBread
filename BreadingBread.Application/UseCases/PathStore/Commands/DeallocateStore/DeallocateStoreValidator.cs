using FluentValidation;

namespace BreadingBread.Application.UseCases.PathStore.Commands.DeallocateStore
{
    public class DeallocateStoreValidator : AbstractValidator<DeallocateStoreCommand>
    {
        public DeallocateStoreValidator()
        {
            RuleFor(el => el.Id).GreaterThan(0);
        }
    }
}
