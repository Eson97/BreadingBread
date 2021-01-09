using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Enfermedades.Commands.DeleteEnfermedad
{
    public class DeleteEnfermedadAuth : IUserRequest<DeleteEnfermedadCommand, DeleteEnfermedadResponse>
    {

        public DeleteEnfermedadAuth()
        {
        }
        
        public Task Validate(DeleteEnfermedadCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
