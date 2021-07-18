using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Products.Queries.GetListProducts
{
    public class GetListProductsAuth : IAuthenticatedRequest<GetListProductsQuery, GetListProductsResponse>
    {

        public GetListProductsAuth()
        {
        }

        public Task Validate(GetListProductsQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
