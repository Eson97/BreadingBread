using MediatR;

namespace BreadingBread.Application.UseCases.Enfermedades.Commands.AgregarEnfermedad
{
    public class AgregarEnfermedadCommand : IRequest<AgregarEnfermedadResponse>
    {
        public string Nombre { get; set; }
    }
}
