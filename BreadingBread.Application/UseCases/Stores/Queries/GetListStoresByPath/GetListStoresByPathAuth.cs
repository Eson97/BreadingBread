using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Queries.GetListStoresByPath
{
    public class GetListStoresByPathAuth : IAdminRequest<GetListStoresByPathQuery, GetListStoresByPathResponse>
    {
        public GetListStoresByPathAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
        }
        
        public Task Validate(GetListStoresByPathQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
