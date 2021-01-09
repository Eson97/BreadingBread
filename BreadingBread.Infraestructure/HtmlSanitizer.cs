using BreadingBread.Application.Interfaces;

namespace BreadingBread.Infraestructure
{
    public class HtmlSanitizer : IHtmlSanitizer
    {
        public string Sanitize(string content)
        {
            var sanitizer = new Ganss.XSS.HtmlSanitizer();
            return sanitizer.Sanitize(content);
        }
    }
}
