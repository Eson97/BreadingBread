using BreadingBread.Application.UseCases.Stores.Commands.SetCoor;
using BreadingBread.WebUi.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Store
{
    public class SetCoor : BaseTestController
    {
        public SetCoor(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task SetCoorSuccessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new SetCoorCommand
            {
                Id = 1,
                Lat = 586.2,
                Long = -135.6
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/SetCoordinates", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<SetCoorResponse>(response);

            Assert.IsType<SetCoorResponse>(result);
        }

        [Fact]
        public async Task SetCoorIdNull()
        {
            var client = await GetAdminClientAsync();

            var pet = new SetCoorCommand
            {
                Lat = 586.2,
                Long = -135.6
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/SetCoordinates", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task SetCoorLatNull()
        {
            var client = await GetAdminClientAsync();

            var pet = new SetCoorCommand
            {
                Id = 1,
                Long = -135.6
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/SetCoordinates", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task SetCoorLongNull()
        {
            var client = await GetAdminClientAsync();

            var pet = new SetCoorCommand
            {
                Id = 1,
                Lat = 586.2
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/SetCoordinates", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task SetCoorIdNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new SetCoorCommand
            {
                Id = 77777,
                Lat = 586.2,
                Long = -135.6
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Store/SetCoordinates", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
