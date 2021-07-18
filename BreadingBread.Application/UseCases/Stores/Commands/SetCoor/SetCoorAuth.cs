using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.SetCoor
{
    public class SetCoorAuth : IUserRequest<SetCoorCommand, SetCoorResponse>
    {
        public Task Validate(SetCoorCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
