using MediatR;
namespace BreadingBread.Application.UseCases.EtapasFenologicas.Commands.AddEtapaFenologica
{
    public class AddEtapaFenologicaCommand : IRequest<AddEtapaFenologicaResponse>
    {
        public string Nombre { get; set; }
    }
}
