using FluentValidation;

namespace BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath
{
    public class DeallocatePathValidator : AbstractValidator<DeallocatePathCommand>
    {
        public DeallocatePathValidator()
        {
            RuleFor(el => el.IdUserPath).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
