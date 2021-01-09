using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Reportes.Commands.AgregarArchivo
{
    public class AgregarArchivoAuth : IAuthenticatedRequest<AgregarArchivoCommand, AgregarArchivoResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public AgregarArchivoAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(AgregarArchivoCommand request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
            //int autorActividad = await db
            //   .ActividadCurso
            //   .Where(el => el.Id == request.IdActividad)
            //   .Select(el => el.Unidad.Curso.IdMaestro)
            //   .SingleOrDefaultAsync();

            //if (autorActividad != currentUser.UserId)
            //{
            //    validationResult.Errors.Add("No creaste la actividad");
            //}
        }
    }
}