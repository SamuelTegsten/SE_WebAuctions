using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.ViewModels;

namespace WebAuctions.Controllers
{
    [Authorize]
    public class AccountPageController : Controller
    {
        private readonly IAuctionService auctionService;

        public AccountPageController(IAuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        public IActionResult Index()
        {
            string userName = User.Identity.Name;
            List<Auction> userAuctions = auctionService.GetAuctionsByName(userName);
            List <AuctionVM> vm = new ();
            foreach (var auction in userAuctions)
            {
                vm.Add(AuctionVM.FromAuction(auction));
            }
            return View(vm);
        }
    }
}
