using FluentValidation;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenValidator : AbstractValidator<InvalidaTokenCommand>
    {
        public InvalidaTokenValidator()
        {
            RuleFor(el => el.RefreshToken).NotEmpty();
        }
    }
}