using BreadingBread.Application.Interfaces;
using FluentValidation;

namespace BreadingBread.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoValidator : AbstractValidator<AgregarArchivoCommand>
    {
        private readonly IBreadingBreadDbContext db;

        public AgregarArchivoValidator(IBreadingBreadDbContext db)
        {
            RuleFor(el => el.Archivo).NotEmpty();
            RuleFor(el => el.IdActividad).NotEmpty().GreaterThan(0);
            this.db = db;
        }
    }
}