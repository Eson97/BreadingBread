using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.RecuperaPasswordGeneraToken
{
    public class RecuperaPasswordGeneraTokenCommand : IRequest<RecuperaPasswordGeneraTokenResponse>
    {
        public string UserName { get; set; }
    }
}