using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.DeleteUsuario
{
    public class DeleteUsuarioCommand : IRequest<DeleteUsuarioResponse>
    {
        public string UserName { get; set; }
    }
}
