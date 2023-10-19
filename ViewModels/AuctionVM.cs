using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
    public class AuctionVM
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public string Auctioneer { get; set; }
        public double OpeningPrice { get; set; }
        public DateTime EndDate { get; set; }


        public static AuctionVM FromAuction(Auction auction)
        {
            return new AuctionVM()
            {
                Id = auction.Id,
                Item = auction.Item,
                Auctioneer = auction.Auctioneer,
                OpeningPrice = auction.OpeningPrice,
                EndDate = auction.EndDate
            };
        }
    }
}
