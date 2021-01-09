using FluentValidation;

namespace BreadingBread.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaValidator : AbstractValidator<AgregarPlagaCommand>
    {
        public AgregarPlagaValidator()
        {
            RuleFor(el => el.Nombre).NotEmpty();
        }
    }
}
