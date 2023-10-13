using Microsoft.AspNetCore.Mvc;

namespace WebAuctions.Controllers
{
    public class AuctionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
