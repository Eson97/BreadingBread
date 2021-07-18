using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleAuth : IUserRequest<AddSaleCommand, AddSaleResponse>
    {
        private readonly IBreadingBreadDbContext db;
        private readonly IUserAccessor currentUser;

        public AddSaleAuth(IBreadingBreadDbContext db, IUserAccessor currentUser)
        {
            this.db = db;
            this.currentUser = currentUser;
        }

        public async Task Validate(AddSaleCommand request, ValidationResult validationResult)
        {
            var userSale = await db.UserSale.FindAsync(request.IdUserSale);

            if (userSale != null && userSale.IdUser != currentUser.UserId)
                validationResult.Errors.Add($"La ruta {userSale.Path.Name} no la transitas tu");
        }
    }
}
