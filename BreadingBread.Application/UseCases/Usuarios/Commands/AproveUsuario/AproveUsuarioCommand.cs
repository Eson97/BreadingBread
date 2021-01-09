using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.AproveUsuario
{
    public class AproveUsuarioCommand : IRequest<AproveUsuarioResponse>
    {
        public string NombreUsuario { get; set; }
    }
}
