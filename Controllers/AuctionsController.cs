using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.Core.Service;
using WebAuctions.ViewModels;

namespace WebAuctions.Controllers
{
    namespace WebAuctions.Controllers
    {
        [Authorize]
        public class AuctionsController : Controller
        {
            private readonly IAuctionService auctionService;
            private readonly IBidService bidService;

            public AuctionsController(IAuctionService auctionService, IBidService bidService)
            {
                this.auctionService = auctionService;
                this.bidService = bidService;
            }

            public IActionResult Index()
            {
                List<Auction> auctions = auctionService.GetAll();
                List<AuctionVM> vm = new();
                foreach (var auction in auctions)
                {
                    vm.Add(AuctionVM.FromAuction(auction));
                }
                return View(vm);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(AuctionVM model)
            {
                System.Diagnostics.Debug.WriteLine("Debug Print - Model:");
                System.Diagnostics.Debug.WriteLine($"Model id: {model.Id}");
                System.Diagnostics.Debug.WriteLine($"Bid Count: {model.Bid.Count}");

                string userName = User.Identity.Name;

                   bidService.addBid(new Bid(model.Id, userName, model.Bid[model.Bid.Count - 1].BidAmount, DateTime.Now));
                   return RedirectToAction("Index");

                return View(model);
            }
        }
    }
}
