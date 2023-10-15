using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public AuctionStatus Status { get; set; }
        public double Bid { get; set; }
        public string Username { get; set; }

        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
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
