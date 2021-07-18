using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Promotions.Queries.GetListPromotion
{
    public class GetListPromotionAuth : IAdminRequest<GetListPromotionQuery, GetListPromotionResponse>
    {

        public GetListPromotionAuth()
        {
        }

        public Task Validate(GetListPromotionQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
