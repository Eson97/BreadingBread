using BreadingBread.WebUi.FunctionalTests.Common;
using System.Threading.Tasks;
using Xunit;
using BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin;
using BreadingBread.Application.UseCases.Usuarios.Commands.CreateUsuario;
using BreadingBread.Domain.Enums;
using System.Net;
using static BreadingBread.WebUi.Controllers.CuentaController;

namespace BreadingBread.WebUi.FunctionalTests.Controllers.Cuenta
{
    public class Login : BaseTestController
    {
        public Login(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task CreateUserAndNotAproveTryLogin()
        {
            var client = GetClient();
            var command = new CreateUserCommand
            {
                UserName = "admin2987",
                UserType = (int)UserType.Admin,
                Password = "123",
                Name = "Nombre",
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/Cuenta/createUser", content);

            var responseContent = await Utilities.GetResponseContent<CreateUsuarioResponse>(response);

            Assert.Equal(command.Name, responseContent.Name);
            Assert.Equal(command.UserName, responseContent.UserName);

            response.EnsureSuccessStatusCode();

            var loginCommand = new GetUserLoginQuery
            {
                UserName = "admin2987",
                Password = "123"
            };

            var contentLogin = Utilities.GetRequestContent(loginCommand);
            var responseLogin = await client.PostAsync($"/api/Cuenta/ingresar", contentLogin);

            Assert.Equal(HttpStatusCode.Forbidden, responseLogin.StatusCode);
        }

        [Fact]
        public async Task UserLoggedInCorrectly()
        {
            var client = GetClient();
            var loginCommand = new GetUserLoginQuery
            {
                UserName = "Admin",
                Password = "123"
            };

            var contentLogin = Utilities.GetRequestContent(loginCommand);
            var response = await client.PostAsync($"/api/Cuenta/ingresar", contentLogin);

            response.EnsureSuccessStatusCode();

            var responseContent = await Utilities.GetResponseContent<IngresarResponse>(response);

            Assert.NotNull(responseContent.Token);
            Assert.NotNull(responseContent.User);
            Assert.NotNull(responseContent.User.RefreshToken);
        }

        [Fact]
        public async Task UserTryLoginNotFound()
        {
            var client = GetClient();
            var loginCommand = new GetUserLoginQuery
            {
                UserName = "UserNotExist",
                Password = "123"
            };

            var contentLogin = Utilities.GetRequestContent(loginCommand);
            var response = await client.PostAsync($"/api/Cuenta/ingresar", contentLogin);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        }
    }
}
