using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Inventory.Queries.GetListInventoryByProduct
{
    public class GetListInventoryByProductAuth : IUserRequest<GetListInventoryByProductQuery, GetListInventoryByProductResponse>
    {
        public GetListInventoryByProductAuth()
        {

        }

        public Task Validate(GetListInventoryByProductQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
