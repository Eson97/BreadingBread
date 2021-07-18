using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Security;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.SaleProduct.Commands.AddProductSale
{
    public class AddProductSaleAuth : IUserRequest<AddProductSaleCommand, AddProductSaleResponse>
    {

        public AddProductSaleAuth()
        {
        }

        public Task Validate(AddProductSaleCommand request, ValidationResult validationResult)
        {
            return Task.CompletedTask;
        }
    }
}
