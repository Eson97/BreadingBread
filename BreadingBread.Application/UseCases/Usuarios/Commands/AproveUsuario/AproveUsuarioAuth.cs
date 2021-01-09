using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioAuth : IAdminRequest<AproveUsuarioCommand, AproveUsuarioResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public AproveUsuarioAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public Task Validate(AproveUsuarioCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
