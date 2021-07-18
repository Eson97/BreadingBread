using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.EditStore
{
    public class EditStoreAuth : IAdminRequest<EditStoreCommand, EditStoreResponse>
    {
        public EditStoreAuth()
        {
        }

        public Task Validate(EditStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
