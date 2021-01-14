using BreadingBread.Application.UseCases.Products.Commands.AddProduct;
using BreadingBread.WebUi.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Product
{
    public class AddProduct : BaseTestController
    {
        public AddProduct(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task AddProductSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductCommand
            {
                Name = "BreadingBread Toast",
                Price = 150.50M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Add", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<AddProductResponse>(response);

            Assert.IsType<AddProductResponse>(result);
        }

        [Fact]
        public async Task AddProductExcededNameLenghtByAdminBadRequest()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductCommand
            {
                Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Price = 10.5M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddProductInvalidPrice()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductCommand
            {
                Name = "Panecito",
                Price = 0
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddProductNoValues()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductCommand
            {
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Fact]
        public async Task AddProductNoNameValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductCommand
            {
                Price = 10.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddProductNoPriceValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddProductCommand
            {
                Name = "Panecirou"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddProductByUserUnhautorized()
        {
            var client = await GetUserClientAsync();

            var pet = new AddProductCommand
            {
                Name = "BreadingBread Toast",
                Price = 50.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Add", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
