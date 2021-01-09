using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuariosList
{
    public class GetUsuariosListAuth : IAdminRequest<GetUsuariosListQuery, GetUsuariosListResponse>
    {
        public Task Validate(GetUsuariosListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}