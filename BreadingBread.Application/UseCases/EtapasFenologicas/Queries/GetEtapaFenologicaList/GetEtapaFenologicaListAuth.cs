using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.EtapasFenologicas.Queries.GetEtapaFenologicaList
{
    public class GetEtapaFenologicaListAuth : IUserRequest<GetEtapaFenologicaListQuery, GetEtapaFenologicaListResponse>
    {

        public GetEtapaFenologicaListAuth()
        {
        }

        public Task Validate(GetEtapaFenologicaListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
