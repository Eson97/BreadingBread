using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotionByProduct
{
    public class GetListPromotionByProductAuth : IAuthenticatedRequest<GetListPromotionByProductQuery, GetListPromotionByProductResponse>
    {
        public GetListPromotionByProductAuth()
        {
        }

        public Task Validate(GetListPromotionByProductQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
