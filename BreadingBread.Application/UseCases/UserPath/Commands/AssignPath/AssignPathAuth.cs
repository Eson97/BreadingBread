using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Commands.AssignPath
{
    public class AssignPathAuth : IUserRequest<AssignPathCommand, AssignPathResponse>
    {

        public AssignPathAuth()
        {
        }

        public Task Validate(AssignPathCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
