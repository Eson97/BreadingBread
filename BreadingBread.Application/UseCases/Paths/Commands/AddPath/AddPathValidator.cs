using FluentValidation;

namespace BreadingBread.Application.UseCases.Paths.Commands.AddPath
{
    public class AddPathValidator : AbstractValidator<AddPathCommand>
    {
        public AddPathValidator()
        {
            RuleFor(el => el.Name).NotEmpty().MaximumLength(20);
        }
    }
}
