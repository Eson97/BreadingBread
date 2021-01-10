using BreadingBread.Domain.Enums;

namespace BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin
{
    public class GetUsuarioLoginResponse
    {
        public int IdUsuario { get; set; }
        public string UserName { get; set; }
        public UserType UserType { get; set; }
        public string RefreshToken { get; set; }
    }
}