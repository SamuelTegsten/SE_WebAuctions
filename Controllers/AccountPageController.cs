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
            AccountVM result = new AccountVM();
            

            string userName = User.Identity.Name;
            List<Auction> auctions = auctionService.GetAll();
            List<Auction> current = auctionService.GetUsersOngoingAuctions(userName, DateTime.Now);

            List<Auction> won = auctionService.GetUsersWonAuctions(userName, DateTime.Now);

            List <AuctionVM> currentVm = new ();
            foreach (var auction in current)
            {
                currentVm.Add(AuctionVM.FromAuction(auction));
            }
            List<AuctionVM> wonVm = new();
            foreach (var auction in won)
            {
                wonVm.Add(AuctionVM.FromAuction(auction));
            }
            result.Current = currentVm;
            result.Won = wonVm;
            return View(result);
        }
    }
}
