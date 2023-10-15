using System.Runtime.Intrinsics.X86;
using Microsoft.AspNetCore.Mvc;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.ViewModels;

namespace WebAuctions.Controllers
{
    public class AuctionPageController : Controller
    {

        private readonly IAuctionService auctionService;

        public AuctionPageController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        public IActionResult Index(int id)
        {
            Auction auctions = auctionService.GetAuctionById(id);
            AuctionVM vm = new();
            vm.Id = id;
            vm.Item = auctions.Item;
            vm.Duration = auctions.Duration;
            vm.Status = auctions.Status;
            vm.Date = auctions.Date;
            vm.Bid = auctions.Bid;
            return View(vm);
        }
    }
}
