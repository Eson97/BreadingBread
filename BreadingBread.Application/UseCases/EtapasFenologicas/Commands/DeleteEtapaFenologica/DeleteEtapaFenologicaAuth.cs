using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.EtapasFenologicas.Commands.DeleteEtapaFenologica
{
    public class DeleteEtapaFenologicaAuth : IUserRequest<DeleteEtapaFenologicaCommand, DeleteEtapaFenologicaResponse>
    {
        public DeleteEtapaFenologicaAuth()
        {
        }
        
        public Task Validate(DeleteEtapaFenologicaCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
