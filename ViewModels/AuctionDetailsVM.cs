using System;
using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
	public class AuctionDetailsVM
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public string Auctioneer { get; set; }
        public double OpeningPrice { get; set; }
        public DateTime EndDate { get; set; }

        public List<BidVM> BidVMs { get; set; } = new();


        public static AuctionDetailsVM FromAuction(Auction auction)
        {
            var detailsVM = new AuctionDetailsVM()
            {
                Id = auction.Id,
                Item = auction.Item,
                Auctioneer = auction.Auctioneer,
                OpeningPrice = auction.OpeningPrice,
                EndDate = auction.EndDate
            };
            foreach(var bid in auction.Bids)
            {
                detailsVM.BidVMs.Add(BidVM.FromBid(bid));
            }
            return detailsVM;
        }
    }
}

