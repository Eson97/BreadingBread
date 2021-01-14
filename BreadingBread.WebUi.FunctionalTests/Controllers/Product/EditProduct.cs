using BreadingBread.Application.UseCases.Products.Commands.EditProduct;
using BreadingBread.WebUi.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Product
{
    public class EditProduct : BaseTestController
    {
        public EditProduct(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task EditSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditProductCommand
            {
                Id = 1,
                Name = "newPathName",
                Price = 100.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<EditProductResponse>(response);

            Assert.IsType<EditProductResponse>(result);
        }

        [Fact]
        public async Task EditProductExcededNameLenghtByAdminBadRequest()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditProductCommand
            {
                Id = 2,
                Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Price = 10.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task EditProductByUserNotAuthorized()
        {
            var client = await GetUserClientAsync();

            var pet = new EditProductCommand
            {
                Id = 1,
                Name = "panecito",
                Price = 20.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EditProductByAdminNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditProductCommand
            {
                Id = 7777,
                Name = "Name to edit",
                Price = 10.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task EditProductNoIdValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditProductCommand
            {
                Name = "Name to edit",
                Price = 10.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task EditProductNoNameValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditProductCommand
            {
                Id = 7777,
                Price = 10.00M
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task EditProductNoPriceValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditProductCommand
            {
                Id = 7777,
                Name = "Name to edit"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task EditProductInvalidPriceValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditProductCommand
            {
                Id = 7777,
                Name = "Name to edit",
                Price = 0
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Product/Edit", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
