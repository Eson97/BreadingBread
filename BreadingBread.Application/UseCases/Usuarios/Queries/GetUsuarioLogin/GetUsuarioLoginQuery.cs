using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUserLoginQuery : IRequest<GetUsuarioLoginResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}