using BreadingBread.Application.UseCases.Stores.Commands.DeleteStore;
using BreadingBread.WebUi.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Store
{
    public class DeleteStore : BaseTestController
    {
        public DeleteStore(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task DeleteSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeleteStoreCommand
            {
                Id = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Delete", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<DeleteStoreResponse>(response);

            Assert.IsType<DeleteStoreResponse>(result);
        }

        [Fact]
        public async Task DeletePathNoId()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeleteStoreCommand
            {
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Delete", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task DeletePathByUserNotAuthorized()
        {
            var client = await GetUserClientAsync();

            var pet = new DeleteStoreCommand
            {
                Id = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/Delete", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EditPathByAdminNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeleteStoreCommand
            {
                Id = 7777
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/delete", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
