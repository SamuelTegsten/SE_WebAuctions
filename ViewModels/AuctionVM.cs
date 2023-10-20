using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime Date { get; set; }
        public List<Bid> Bid { get; set; }
        public string auctionName { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Item = auction.Item,
                ExpirationDate = auction.ExpirationDate,
                Date = auction.Date,
                Bid = auction.Bid,
                auctionName = auction.AuctionName
            };
        }
    }
}
