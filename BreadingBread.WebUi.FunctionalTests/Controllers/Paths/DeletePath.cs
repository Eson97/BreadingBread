using BreadingBread.Application.UseCases.Paths.Commands.DeletePath;
using BreadingBread.Application.UseCases.Paths.Commands.EditPath;
using BreadingBread.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Paths
{
    public class DeletePath : BaseTestController
    {
        public DeletePath(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task DeleteSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new DeletePathCommand
            {
                Id = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Delete", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<DeletePathResponse>(response);

            Assert.IsType<DeletePathResponse>(result);
        }

        [Fact]
        public async Task DeletePathNoId()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditPathCommand
            {
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Delete", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task DeletePathByUserNotAuthorized()
        {
            var client = await GetUserClientAsync();

            var pet = new EditPathCommand
            {
                Id = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Delete", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EditPathByAdminNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditPathCommand
            {
                Id = 7777
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/delete", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
