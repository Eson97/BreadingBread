using FluentValidation;

namespace BreadingBread.Application.UseCases.Stores.Commands.SetCoor
{
    public class SetCoorValidator : AbstractValidator<SetCoorCommand>
    {
        public SetCoorValidator()
        {
            RuleFor(el => el.Id).NotEmpty();
            RuleFor(el => el.Lat).NotEmpty();
            RuleFor(el => el.Long).NotEmpty();
        }
    }
}
