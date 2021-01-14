using BreadingBread.Application.UseCases.Stores.Commands.AddStore;
using BreadingBread.WebUi.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Store
{
    public class AddStore : BaseTestController
    {
        public AddStore(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task AddStoreSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddStoreCommand
            {
                IdPath = 1,
                Name = "tienda"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Add", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<AddStoreResponse>(response);

            Assert.IsType<AddStoreResponse>(result);
        }

        [Fact]
        public async Task AddStoreExcededNameLenghtByAdminBadRequest()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddStoreCommand
            {
                Name = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                IdPath = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddStoreNoNameValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddStoreCommand
            {
                IdPath = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddStoreNoIdPathValue()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddStoreCommand
            {
                Name = "Mi Tiendita"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddStoreIdPathNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddStoreCommand
            {
                Name = "Mi Tiendita",
                IdPath = 77777
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Add", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task AddStoreByUserUnhautorized()
        {
            var client = await GetUserClientAsync();

            var pet = new AddStoreCommand
            {
                Name = "Mi Tiendita",
                IdPath = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Add", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
