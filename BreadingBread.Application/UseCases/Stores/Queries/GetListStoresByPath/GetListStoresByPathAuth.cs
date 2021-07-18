using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathAuth : IUserRequest<GetListStoresByPathQuery, GetListStoresByPathResponse>
    {
        public GetListStoresByPathAuth()
        {
        }

        public Task Validate(GetListStoresByPathQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
