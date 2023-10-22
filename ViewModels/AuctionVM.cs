using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public string Auctioneer { get; set; }
        public ItemVM Item { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime Date { get; set; }
        public List<BidVM> Bid { get; set; }
        public string auctionName { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            List<BidVM> tempBid = new List<BidVM>();
            foreach(var b in auction.Bid)
            {
                tempBid.Add(BidVM.FromBid(b));
            }
            return new AuctionVM()
            {
                Id = auction.Id,
                Auctioneer = auction.Auctioneer,
                Item = ItemVM.FromItem(auction.Item),
                ExpirationDate = auction.ExpirationDate,
                Date = auction.Date,
                Bid = tempBid,
                auctionName = auction.AuctionName
            };
        }

        public decimal getHighestBid()
        {
            decimal max = 0;
            foreach(var bid in Bid)
            {
                if (bid.BidAmount > max)
                {
                    max = bid.BidAmount;
                }
            }
            return max;
        }
    }
}
