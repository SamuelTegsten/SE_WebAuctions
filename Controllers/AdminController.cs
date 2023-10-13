using Microsoft.AspNetCore.Mvc;

namespace WebAuctions.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
