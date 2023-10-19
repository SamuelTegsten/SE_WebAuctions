using Microsoft.AspNetCore.Mvc;
using WebAuctions.Core.Interfaces.Service;

namespace WebAuctions.Controllers
{
    public class CreateAuctionController : Controller
    {
        private readonly IAuctionService auctionService;

        public CreateAuctionController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
