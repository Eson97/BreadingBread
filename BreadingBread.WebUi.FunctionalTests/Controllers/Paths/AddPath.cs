using BreadingBread.Application.UseCases.Paths.Commands.AddPath;
using BreadingBread.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Paths
{
    public class AddPath : BaseTestController
    {
        public AddPath(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task AddPathSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddPathCommand
            {
                Name = "new Path to add"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Add", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<AddPathResponse>(response);

            Assert.IsType<AddPathResponse>(result);
        }

        [Fact]
        public async Task AddPathExcededNameLenghtByAdminBadRequest()
        {
            var client = await GetAdminClientAsync();

            var pet = new AddPathCommand
            {
                Name = "new Path to add bastante grande al parecer y no funciona"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Add", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task AddPathByUserUnhautorized()
        {
            var client = await GetUserClientAsync();

            var pet = new AddPathCommand
            {
                Name = "new Path to add"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Add", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
