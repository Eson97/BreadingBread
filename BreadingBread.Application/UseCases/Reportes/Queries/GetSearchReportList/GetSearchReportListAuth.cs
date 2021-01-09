using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Reportes.Queries.GetSearchReportList
{
    public class GetSearchReportListAuth : IAuthenticatedRequest<GetSearchReportListQuery, GetSearchReportListResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public GetSearchReportListAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public Task Validate(GetSearchReportListQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
