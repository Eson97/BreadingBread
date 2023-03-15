using Microsoft.AspNetCore.Mvc;

namespace BreadingBread.WebUi.Controllers
{
    public class HomeController : BaseWebController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
