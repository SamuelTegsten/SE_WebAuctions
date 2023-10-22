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
            

            //Leading auctions
            string userName = User.Identity.Name;
            List<Auction> auctions = auctionService.GetAll();
            List<Auction> leading = new List<Auction>();
            List<Auction> won = new List<Auction>();
            string highest = "";
            foreach(var a in auctions)
            {
                highest = a.getHighestBidder();
                if(highest == userName)
                {
                    if (a.ExpirationDate > DateTime.Now)
                    {
                        leading.Add(a);
                    }
                    else
                    {
                        won.Add(a);
                    }
                }
            }

            List <AuctionVM> leadingVm = new ();
            foreach (var auction in leading)
            {
                leadingVm.Add(AuctionVM.FromAuction(auction));
            }
            List<AuctionVM> wonVm = new();
            foreach (var auction in won)
            {
                wonVm.Add(AuctionVM.FromAuction(auction));
            }
            result.Leading = leadingVm;
            result.Won = wonVm;
            return View(result);
        }
    }
}
