using Microsoft.AspNetCore.Mvc;

namespace WebAuctions.Controllers
{
    public class AuctionPageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
