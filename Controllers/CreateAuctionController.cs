using System.Drawing.Printing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;
using WebAuctions.ViewModels;

namespace WebAuctions.Controllers
{
    public class AuctionViewModel
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Bid> Bid { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

    public class CreateAuctionController : Controller
    {
        private readonly IAuctionService auctionService;
        private readonly IItemService itemService;
        private readonly IBidService bidService;

        public CreateAuctionController(IAuctionService auctionService, IItemService itemService, IBidService bidService)
        {
            this.auctionService = auctionService;
            this.itemService = itemService;
            this.bidService = bidService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateAuctionVM model)
        {
            string userName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                var auction = new Auction(
                    0,
                    userName,
                    new Item("images/" + model.Picture, model.AuctionName, model.Description),
                    model.ExpirationDate,
                    DateTime.Now,
                    null,
                    model.AuctionName
                    );
                int auctionId = auctionService.AddAuction(auction);
                System.Diagnostics.Debug.WriteLine("AuctionId: " + auctionId);

                bidService.addBid(new Bid(auctionId, userName, model.Price, DateTime.Now));
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
