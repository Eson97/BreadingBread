using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.ModificarDatosUsuario
{
    public class ModificarDatosUsuarioCommand : IRequest<ModificarDatosUsuarioResponse>
    {
        public int IdUsuario { get; set; }
        public string Name { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}