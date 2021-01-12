using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUserCommand : IRequest<CreateUsuarioResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
        public string Name { get; set; }
    }
}