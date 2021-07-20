using BreadingBread.Application.UseCases.Promotions.Commands.DeletePromotion;
using BreadingBread.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Inventory
{
    public class DeleteInventory : BaseTestController
    {
        public DeleteInventory(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task DeleteSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeletePromotionCommand
            {
                Id = 2
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Delete", content);

            response.EnsureSuccessStatusCode();
            var result = await Utilities.GetResponseContent<DeletePromotionResponse>(response);
            Assert.IsType<DeletePromotionResponse>(result);
        }

        [Fact]
        public async Task DeleteUserSucessful()
        {
            var client = await GetUserClientAsync();

            var pet = new DeletePromotionCommand
            {
                Id = 3
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Delete", content);

            response.EnsureSuccessStatusCode();
            var result = await Utilities.GetResponseContent<DeletePromotionResponse>(response);
            Assert.IsType<DeletePromotionResponse>(result);
        }

        [Fact]
        public async Task DeleteInventoryNoId()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeletePromotionCommand
            {
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Delete", content);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task DeleteInventoryByAdminNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeletePromotionCommand
            {
                Id = 7777
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Delete", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task DeleteInventoryByUserNotFound()
        {
            var client = await GetUserClientAsync();

            var pet = new DeletePromotionCommand
            {
                Id = 7777
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Inventory/Delete", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
