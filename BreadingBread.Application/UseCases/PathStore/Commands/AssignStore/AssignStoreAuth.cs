using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.PathStore.Commands.AssignStore
{
    public class AssignStoreAuth : IUserRequest<AssignStoreCommand, AssignStoreResponse>
    {

        public AssignStoreAuth()
        {
        }

        public Task Validate(AssignStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
