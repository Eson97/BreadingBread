using BreadingBread.Application.Interfaces;
using BreadingBread.Application.UseCases.Usuarios.Queries.GetUsuarioLogin;
using BreadingBread.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.FunctionalTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            bool useSqlite = true;

            builder.ConfigureServices(services =>
            {
                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                if (useSqlite)
                {
                    // SQLite needs to open connection to the DB.
                    // Not required for in-memory-database.
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    services.AddDbContext<BreadingBreadDbContext>(options =>
                    {
                        options.UseSqlite(connection);
                    });
                }
                else
                {
                    // Add a database context using an in-memory 
                    // database for testing.
                    services.AddDbContext<BreadingBreadDbContext>(options =>
                    {

                        options.UseInMemoryDatabase("InMemoryDbForTesting");
                        options.UseInternalServiceProvider(serviceProvider);
                    });
                }
                services.AddScoped<IBreadingBreadDbContext>(provider => provider.GetService<BreadingBreadDbContext>());

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (BreadingBreadDbContext)
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<IBreadingBreadDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    var concreteContext = (BreadingBreadDbContext)context;

                    // Ensure the database is created.
                    concreteContext.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        Utilities.InitializeDbForTests(concreteContext);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                        throw ex;
                    }
                }
            });
        }

        public HttpClient GetAnonymousClient(Action<IServiceCollection> configuration = null)
        {
            if (configuration != null)
            {
                return WithWebHostBuilder(conf =>
                {
                    conf.ConfigureTestServices(configuration);
                    // ConfigureWebHost(conf);
                }).CreateClient();
            }
            else
            {
                return CreateClient();
            }
        }

        public async Task<HttpClient> GetAuthenticatedClientAsync(string userName, string password, Action<IServiceCollection> configuration = null)
        {
            var client = GetAnonymousClient(configuration);

            var token = await GetAccessTokenAsync(client, userName, password);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return client;
        }

        public async Task<HttpClient> GetAdminClientAsync(Action<IServiceCollection> configuration = null)
        {
            return await GetAuthenticatedClientAsync("Admin", "123", configuration);
        }
        public async Task<HttpClient> GetMaestroClientAsync(Action<IServiceCollection> configuration = null)
        {
            return await GetAuthenticatedClientAsync("Maestro", "123", configuration);
        }
        public async Task<HttpClient> GetAlumnoClientAsync(Action<IServiceCollection> configuration = null)
        {
            return await GetAuthenticatedClientAsync("Alumno", "123", configuration);
        }

        private async Task<string> GetAccessTokenAsync(HttpClient client, string userName, string password)
        {
            string content = JsonConvert.SerializeObject(new GetUserLoginQuery
            {
                UserName = userName,
                Password = password
            });

            using (var response = await client.PostAsync("/api/cuenta/ingresar", new StringContent(content, Encoding.UTF8, "application/json")))
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<WebUi.Controllers.CuentaController.IngresarResponse>(responseString);
                if (result.Token == null)
                {
                    throw new Exception("No se encontro el usuario, db necesita seed");
                }
                return result.Token;
            }
        }
    }

}