using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.UserPath.Commands.DeallocatePath
{
    public class DeallocatePathAuth : IUserRequest<DeallocatePathCommand, DeallocatePathResponse>
    {
        public DeallocatePathAuth()
        {
        }

        public Task Validate(DeallocatePathCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
