using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.ReportSales.Queries.GetSalesReportList
{
    public class GetSalesReportListAuth : IAuthenticatedRequest<GetSalesReportListQuery, GetSalesReportListResponse>
    {
        public GetSalesReportListAuth()
        {
        }

        public Task Validate(GetSalesReportListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
