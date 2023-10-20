namespace WebAuctions.Core.Model
{
    public class Auction
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public string Auctioneer { get; set; }
        public double OpeningPrice { get; set; }
        public DateTime EndDate { get; set; }

        private List<Bid> _bids = new List<Bid>();
        public IEnumerable<Bid> Bids => _bids;

        public Auction(int id, Item item, string auctioneer, double openingPrice, DateTime endDate)
        {
            Id = id;
            Item = item;
            Auctioneer = auctioneer;
            OpeningPrice = openingPrice;
            EndDate = endDate;

        }

        public void AddBid(Bid newBid)
        {
            _bids.Add(newBid);
        }
    }
}
