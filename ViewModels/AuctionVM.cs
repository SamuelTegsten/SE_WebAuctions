using WebAuctions.Core;

namespace WebAuctions.ViewModels
{
    public class AuctionVM
    {
        public Item Item { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
        public AuctionStatus Status { get; set; }
        public double Bid { get; set; }
        public string Username { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Item = auction.Item,
                Duration = auction.Duration,
                Date = auction.Date,
                Status = auction.Status,
                Bid = auction.Bid,
                Username = auction.Username
            };
        }
    }
}
