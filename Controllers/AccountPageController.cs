using Microsoft.AspNetCore.Mvc;

namespace WebAuctions.Controllers
{
    public class AccountPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
