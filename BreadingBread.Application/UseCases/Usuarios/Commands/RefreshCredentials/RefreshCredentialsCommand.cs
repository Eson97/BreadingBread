using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.RefreshCredentials
{
    public class RefreshCredentialsCommand : IRequest<RefreshCredentialsResponse>
    {
        public string RefreshToken { get; set; }
        public string Token { get; set; }
    }
}