using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUsuarioLoginQuery : IRequest<GetUsuarioLoginResponse>
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
    }
}