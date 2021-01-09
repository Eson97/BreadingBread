using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using System.Threading.Tasks;

namespace BreadingBread.WebUi.FunctionalTests.Mocks
{
    public class EmailServiceMock : IEmailService
    {
        public Task SendAsync(Email message)
        {
            return Task.CompletedTask;
        }
    }
}