using System.IO;
using System.Net.Mail;

namespace BreadingBread.Application.Notifications.Models
{
    public class Email
    {
        public string NameTo { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public bool IsBodyHtml { get; set; } = false;
        public byte[] Attachment { get; set; }
        public string FileName { get; set; }
    }
}
