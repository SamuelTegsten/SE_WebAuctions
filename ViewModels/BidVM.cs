using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
    public class BidVM
    {
        public int Id { get; set; }
        public decimal BidAmount { get; set; }
        public DateTime BidPlacedTime { get; set; }
        public string BidderName { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                BidAmount = bid.BidAmount,
                BidPlacedTime = bid.BidPlacedTime,
                BidderName = bid.BidderName
            };
        }
    }
}
