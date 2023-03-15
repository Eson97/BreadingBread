using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetExcelByUserSale
{
    public class GetExcelByUserSaleAuth : IAuthenticatedRequest<GetExcelByUserSaleQuery, GetExcelByUserSaleResponse>
    {
        public GetExcelByUserSaleAuth()
        {
        }

        public Task Validate(GetExcelByUserSaleQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
