using BreadingBread.Application.UseCases.Paths.Commands.AddPath;
using BreadingBread.WebUi.FunctionalTests.Common;
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
        public async Task AddSucessful()
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
    }
}
