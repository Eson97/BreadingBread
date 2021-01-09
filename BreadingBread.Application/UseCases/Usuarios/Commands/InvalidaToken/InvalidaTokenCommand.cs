using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.InvalidaToken
{
    public class InvalidaTokenCommand : IRequest<InvalidaTokenResponse>
    {
        public string RefreshToken { get; set; }
    }
}