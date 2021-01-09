using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace BreadingBread.Infraestructure
{
    public class PushNotificationService : IPushNotificationService
    {
        public Task SendAsync(PushNotification message)
        {
            throw new NotImplementedException();
        }
    }
}
