﻿using System.Runtime.Intrinsics.X86;
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
        private readonly IItemService itemService;

        public AuctionPageController(IAuctionService auctionService, IItemService itemService)
        {
            this.auctionService = auctionService;
            this.itemService = itemService;
        }

        public IActionResult Index(int id)
        {

            Auction auctions = auctionService.GetAuctionById(id);
            List<BidVM> tempBid = new List<BidVM>();

            foreach (var b in auctions.Bid)
            {
            tempBid.Add(BidVM.FromBid(b));
            }

            AuctionVM vm = new();
            vm.Id = id;
            vm.Item = ItemVM.FromItem(auctions.Item);
            vm.ExpirationDate = auctions.ExpirationDate;
            vm.Date = auctions.Date;
            vm.Bid = tempBid;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AuctionVM model)
        {
            itemService.UpdateDescription(model.Item.Name, model.Item.Description);
            return RedirectToAction("Index", new { id = model.Id });
        }
    }
}
