using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Plagas.Commands.DeletePlaga
{
    public class DeletePlagaAuth : IUserRequest<DeletePlagaCommand, DeletePlagaResponse>
    {
        public DeletePlagaAuth()
        {
        }
        
        public Task Validate(DeletePlagaCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
