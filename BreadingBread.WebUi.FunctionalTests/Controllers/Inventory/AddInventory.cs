using BreadingBread.Application.UseCases.Inventory.Commands.AddProductToInventory;
using BreadingBread.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Inventory
{
    public class AddInventory : BaseTestController
    {
        public AddInventory(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task AddInventorySucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductToInventoryCommand
            {
                IdProduct = 1,
                IdSaleUser = 1,
                InitialCantity = 100
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Add", content);

            response.EnsureSuccessStatusCode();
            var result = await Utilities.GetResponseContent<AddProductToInventoryResponse>(response);
            Assert.IsType<AddProductToInventoryResponse>(result);
        }

        [Fact]
        public async Task AddInventoryBadRequest()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductToInventoryCommand
            {
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddInventoryByUserSucessful()
        {
            var client = await GetUserClientAsync();

            var pet = new AddProductToInventoryCommand
            {
                IdProduct = 1,
                IdSaleUser = 1,
                InitialCantity = 100
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Add", content);


            response.EnsureSuccessStatusCode();
            var result = await Utilities.GetResponseContent<AddProductToInventoryResponse>(response);
            Assert.IsType<AddProductToInventoryResponse>(result);
        }
    }
}
