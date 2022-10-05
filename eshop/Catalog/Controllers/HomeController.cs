using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}
