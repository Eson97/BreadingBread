using BreadingBread.Application.UseCases.Products.Commands.DeleteProduct;
using BreadingBread.WebUi.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Product
{
    public class DeleteProduct : BaseTestController
    {
        public DeleteProduct(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task DeleteSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeleteProductCommand
            {
                Id = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Delete", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<DeleteProductResponse>(response);

            Assert.IsType<DeleteProductResponse>(result);
        }

        [Fact]
        public async Task DeletePathNoId()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeleteProductCommand
            {
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Delete", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task DeletePathByUserNotAuthorized()
        {
            var client = await GetUserClientAsync();

            var pet = new DeleteProductCommand
            {
                Id = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Delete", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EditPathByAdminNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeleteProductCommand
            {
                Id = 7777
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/delete", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
