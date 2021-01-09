using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioAuth : IAdminRequest<DeleteUsuarioCommand, DeleteUsuarioResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public DeleteUsuarioAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public Task Validate(DeleteUsuarioCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
