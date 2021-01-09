using BreadingBread.Application.Notifications.Models;
using System.Threading.Tasks;

namespace BreadingBread.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(Email message);
    }
}
