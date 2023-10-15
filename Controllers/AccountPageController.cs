using Microsoft.AspNetCore.Mvc;
using WebAuctions.Core.Model;
using WebAuctions.ViewModels;

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
