using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Sale.Commands.AddSale
{
    public class AddSaleAuth : IUserRequest<AddSaleCommand, AddSaleResponse>
    {

        public Task Validate(AddSaleCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
