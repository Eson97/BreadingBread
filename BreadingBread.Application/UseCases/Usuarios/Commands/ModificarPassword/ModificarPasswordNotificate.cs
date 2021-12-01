using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.ModificarPassword
{
    public class ModificarPasswordNotificate : INotification
    {
        public string Email { get; set; }

        public class ReenviarEmailHandler : INotificationHandler<ModificarPasswordNotificate>
        {
            private readonly IEmailService emailService;
            private readonly IBreadingBreadDbContext db;

            public ReenviarEmailHandler(IEmailService emailService, IBreadingBreadDbContext db)
            {
                this.emailService = emailService;
                this.db = db;
            }

            public async Task Handle(ModificarPasswordNotificate notification, CancellationToken cancellationToken)
            {
                var usuario = await db
               .User
               .Select(el => new ModificarPasswordResponse
               {
               })
               .SingleOrDefaultAsync(cancellationToken);

                //TODO Delete email service 
                await emailService.SendAsync(new Email
                {
                    Body = $"Se ha modificado la contraseña",
                    To = "AppIAS",
                    Subject = "Modificacion Exitosa"
                });
            }
        }
    }
}