using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Reportes.Commands.AgregarReporte
{
    public class AgregarReporteAuth : IAuthenticatedRequest<AgregarReporteCommand, AgregarReporteResponse>
    {
        private readonly IUserAccessor currentUser;
        private readonly IBreadingBreadDbContext db;

        public AgregarReporteAuth(IUserAccessor currentUser, IBreadingBreadDbContext db)
        {
            this.currentUser = currentUser;
            this.db = db;
        }

        public async Task Validate(AgregarReporteCommand request, ValidationResult validationResult)
        {
            await Task.CompletedTask;
        }
    }
}