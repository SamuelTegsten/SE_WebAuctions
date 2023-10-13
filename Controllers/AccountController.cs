using Microsoft.AspNetCore.Mvc;

namespace WebAuctions.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
