using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Stores.Commands.AddStore
{
    public class AddStoreAuth : IAdminRequest<AddStoreCommand, AddStoreResponse>
    {
        public AddStoreAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {

        }
        
        public Task Validate(AddStoreCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
