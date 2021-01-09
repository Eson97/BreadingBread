using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Reportes.Commands.EditarReporte
{
    public class EditarReporteAuth : IAuthenticatedRequest<EditarReporteCommand, EditarReporteResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public EditarReporteAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(EditarReporteCommand request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
            //var unidad = await db
            //        .ActividadCurso
            //        .Where(el => el.Id == request.IdActividad)
            //        .Select(el => new { el.Unidad.Curso.IdMaestro, el.BloquearEnvios })
            //        .SingleOrDefaultAsync();

            //if (unidad.IdMaestro != currentUser.UserId)
            //{
            //    validationResult.Errors.Add("Maestro No Autorizado");
            //}
        }
    }
}