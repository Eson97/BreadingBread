using MediatR;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.ReenviarEmail
{
    public class ReenviarEmailCommand : IRequest<ReenviarEmailResponse>
    {
        public string Email { get; set; }
    }
}