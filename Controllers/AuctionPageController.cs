using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.ViewModels;

namespace WebAuctions.Controllers
{
    [Authorize]
    public class AuctionPageController : Controller
    {

        private readonly IAuctionService auctionService;

        public AuctionPageController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        public IActionResult Index(int id)
        {
            Auction auction = auctionService.GetAuctionById(id);
            AuctionVM vm = AuctionVM.FromAuction(auction);
            return View(vm);
        }
    }
}
