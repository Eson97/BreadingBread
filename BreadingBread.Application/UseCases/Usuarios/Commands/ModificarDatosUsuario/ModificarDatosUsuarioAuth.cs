using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario
{
    public class ModificarDatosUsuarioAuth : IAuthenticatedRequest<ModificarDatosUsuarioCommand, ModificarDatosUsuarioResponse>
    {
        public Task Validate(ModificarDatosUsuarioCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}