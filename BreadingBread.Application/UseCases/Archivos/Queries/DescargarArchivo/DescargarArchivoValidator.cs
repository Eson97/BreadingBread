using FluentValidation;

namespace BreadingBread.Application.UseCases.Archivos.Queries.DescargarArchivo
{
    public class DescargarArchivoValidator : AbstractValidator<DescargarArchivoQuery>
    {
        public DescargarArchivoValidator()
        {
            RuleFor(el => el.Hash).NotEmpty();
        }
    }
}