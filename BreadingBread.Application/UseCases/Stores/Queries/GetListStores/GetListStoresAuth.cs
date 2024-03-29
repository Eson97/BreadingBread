using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStores
{
    public class GetListStoresAuth : IUserRequest<GetListStoresQuery, GetListStoresResponse>
    {

        public GetListStoresAuth()
        {

        }

        public Task Validate(GetListStoresQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
