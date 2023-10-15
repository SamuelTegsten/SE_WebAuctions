using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.ViewModels;

namespace WebAuctions.Controllers
{
    namespace WebAuctions.Controllers
    {
        public class AuctionsController : Controller
        {
            private readonly IAuctionService auctionService;

            public AuctionsController(IAuctionService auctionService)
            {
                this.auctionService = auctionService;
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
        }
    }
}
