using FluentValidation;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken
{
    public class RecuperaPasswordGeneraTokenValidator : AbstractValidator<RecuperaPasswordGeneraTokenCommand>
    {
        public RecuperaPasswordGeneraTokenValidator()
        {
            RuleFor(el => el.UserName).EmailAddress();
        }
    }
}