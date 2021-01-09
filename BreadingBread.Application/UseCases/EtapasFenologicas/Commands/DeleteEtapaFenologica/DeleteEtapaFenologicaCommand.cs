using MediatR;

namespace BreadingBread.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica
{
    public class DeleteEtapaFenologicaCommand : IRequest<DeleteEtapaFenologicaResponse>
    {
        public int IdEtapa { get; set; }
    }
}
