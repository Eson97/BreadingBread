﻿using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using BreadingBread.Application.Options;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace BreadingBread.Application.UseCases.Usuarios.Commands.CreateUsuario
{
    public class CreateUsuarioNotificate : INotification
    {
        public int IdUsuario { get; set; }

        public class UsuarioCreatedHandler : INotificationHandler<CreateUsuarioNotificate>
        {
            private readonly IEmailService emailService;
            private readonly IBreadingBreadDbContext db;
            private readonly AppSettings settings;

            public UsuarioCreatedHandler(IEmailService emailService, IBreadingBreadDbContext db, IOptions<AppSettings> options)
            {
                this.emailService = emailService;
                this.db = db;
                this.settings = options.Value;
            }

            public async Task Handle(CreateUsuarioNotificate notification, CancellationToken cancellationToken)
            {
                var usuario = await db.User.FindAsync(notification.IdUsuario);
                await emailService.SendAsync(new Email
                {
                    Body = $"Su usuario ha sido registrado, acceda al siguiente link para <a href='{settings.AppUrl}/cuenta/confirmar?token={usuario.TokenConfirmacion}'>confirmar</a>, de lo contrario puede ignorar el email.",
                    From = "AppIAS",
                    Subject = "Registro Completo",
                    IsBodyHtml = true
                });
            }
        }
    }
}