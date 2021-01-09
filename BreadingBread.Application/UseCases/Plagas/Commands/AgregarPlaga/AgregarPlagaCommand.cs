using MediatR;

namespace BreadingBread.Application.UseCases.Plagas.Commands.AgregarPlaga
{
    public class AgregarPlagaCommand : IRequest<AgregarPlagaResponse>
    {
        public string Nombre { get; set; }
    }
}
