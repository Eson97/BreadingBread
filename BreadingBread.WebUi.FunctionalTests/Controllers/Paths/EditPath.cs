using BreadingBread.Application.UseCases.Paths.Commands.EditPath;
using BreadingBread.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Paths
{
    public class EditPath : BaseTestController
    {
        public EditPath(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task EditSucessful()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditPathCommand
            {
                Id = 1,
                Name = "newPathName"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Edit", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<EditPathResponse>(response);

            Assert.IsType<EditPathResponse>(result);
        }

        [Fact]
        public async Task EditPathExcededNameLenghtByAdminBadRequest()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditPathCommand
            {
                Id = 2,
                Name = "a new path name with a name lenght no valid "
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Edit", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task EditPathByUserNotAuthorized()
        {
            var client = await GetUserClientAsync();

            var pet = new EditPathCommand
            {
                Id = 1,
                Name = "newPathName"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Edit", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task EditPathByAdminNotFound()
        {
            var client = await GetAdminClientAsync();

            var pet = new EditPathCommand
            {
                Id = 7777,
                Name = "Name to edit"
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Path/Edit", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
