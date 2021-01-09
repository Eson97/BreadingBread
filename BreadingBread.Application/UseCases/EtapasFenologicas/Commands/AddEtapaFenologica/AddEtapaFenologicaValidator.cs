using FluentValidation;
namespace BreadingBread.Application.UseCases.EtapasFenologicas.Commands.AddEtapaFenologica
{
    public class AddEtapaFenologicaValidator : AbstractValidator<AddEtapaFenologicaCommand>
    {
        public AddEtapaFenologicaValidator()
        {
            RuleFor(el => el.Nombre).NotEmpty();
        }
    }
}
