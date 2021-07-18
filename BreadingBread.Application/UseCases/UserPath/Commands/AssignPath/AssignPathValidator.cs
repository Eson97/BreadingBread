using FluentValidation;

namespace BreadingBread.Application.UseCases.UserPath.Commands.AssignPath
{
    public class AssignPathValidator : AbstractValidator<AssignPathCommand>
    {
        public AssignPathValidator()
        {
            RuleFor(el => el.IdPath).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(el => el.IdUser).NotEmpty().GreaterThanOrEqualTo(0);
        }
    }
}
