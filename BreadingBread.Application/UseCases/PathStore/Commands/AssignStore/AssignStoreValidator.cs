using FluentValidation;

namespace BreadingBread.Application.UseCases.PathStore.Commands.AssignStore
{
    public class AssignStoreValidator : AbstractValidator<AssignStoreCommand>
    {
        public AssignStoreValidator()
        {
            RuleFor(el => el.IdPath).GreaterThan(0);
            RuleFor(el => el.IdStores).ForEach(el=>el.GreaterThan(0));
        }
    }
}
