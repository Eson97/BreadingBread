using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Queries.GetPathByUser
{
    public class GetPathByUserAuth : IUserRequest<GetPathByUserQuery, GetPathByUserResponse>
    {
        public GetPathByUserAuth()
        {
        }

        public Task Validate(GetPathByUserQuery request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
