using BreadingBread.Application.Notifications.Models;
using MimeKit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreadingBread.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(Email message);
    }
}
