using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAuctions.Areas.Identity.Data;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.Persistence;
using WebAuctions.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAuctions.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAuctionsController : Controller
    {

        private readonly IAuctionService auctionService;
        private readonly UserManager<WebAuctionsUser> _userManager;


        public AdminAuctionsController(IAuctionService auctionService, UserManager<WebAuctionsUser> userManager)
        {
            this.auctionService = auctionService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Index(string action, string searchUsername)
        {
            List<AuctionVM> auctionsVM = new List<AuctionVM>();
            List<Auction> auctions = new List<Auction>();
            switch (action)
            {
                case "searchUser":
                     auctions = auctionService.GetAuctionByUserName(searchUsername);
                    foreach (Auction auction in auctions)
                    {
                        auctionsVM.Add(AuctionVM.FromAuction(auction));
                    }
                    break;

                case "showAll":
                   
                    auctions = auctionService.GetAll();
                    foreach (Auction auction in auctions)
                    {
                        auctionsVM.Add(AuctionVM.FromAuction(auction));
                    }
                    break;

            }
            return View(auctionsVM);




        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int auctionId)
        {
            auctionService.DeleteAuctionById(auctionId);
            return RedirectToAction("Index");
        }

    }
}








