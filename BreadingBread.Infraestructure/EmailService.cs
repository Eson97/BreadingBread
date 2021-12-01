using BreadingBread.Application.Interfaces;
using BreadingBread.Application.Notifications.Models;
using BreadingBread.Infraestructure.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;

namespace BreadingBread.Infraestructure
{
    public class EmailService : IEmailService
    {
        private readonly EmailServiceOptions options;
        public EmailService(IOptions<EmailServiceOptions> options)
        {
            this.options = options.Value;
        }
        public async Task SendAsync(Email emailRequest)
        {
            if (options.Enabled)
            {
                var format = emailRequest.IsBodyHtml ? MimeKit.Text.TextFormat.Html : MimeKit.Text.TextFormat.Text;
                var builder = new BodyBuilder();
                var msg = new MimeMessage
                {
                    Subject = emailRequest.Subject,
                    Body = new TextPart(format)
                    {
                        Text = emailRequest.Body,
                    },
                };

                if (emailRequest.FileName != null && emailRequest.Attachment != null)
                    builder.Attachments.Add(fileName: emailRequest.FileName, emailRequest.Attachment);

                msg.To.Add(new MailboxAddress(emailRequest.NameTo, emailRequest.To));
                msg.From.Add(new MailboxAddress(options.Email, options.Email));

                using var client = new SmtpClient();

                client.Connect(options.Host, options.Port);


                // Note: since we don't have an OAuth2 token, disable
                // the XOAUTH2 authentication mechanism.
                // O usar https://stackoverflow.com/a/33501052
                client.AuthenticationMechanisms.Remove("XOAUTH2");

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate(options.Email, options.Password);

                await client.SendAsync(msg);
                client.Disconnect(true);
            }
        }
    }
}
