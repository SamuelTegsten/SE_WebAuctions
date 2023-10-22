namespace WebAuctions.Core.Model
{
    public class Auction
    {
        public int Id { get; set; }
        public string Auctioneer { get; internal set; }
        public Item Item { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime Date { get; set; }
        public List<Bid> Bid { get; set; }
        public string AuctionName { get; set; }

        public Auction(int Id, string Auctioneer,Item item, DateTime expirationDate, DateTime date, List<Bid> bid, string auctionName)
        {
            this.Id = Id;
            this.Auctioneer = Auctioneer;
            this.Item = item;
            this.ExpirationDate = expirationDate;
            this.Date = date;
            this.Bid = bid;
            this.AuctionName = auctionName;
        }


        public string getHighestBidder()
        {
            decimal max = 0;
            string maxBidder = "";
            foreach (var b in Bid)
            {
                if (b.BidAmount > max)
                {
                    max = b.BidAmount;
                    maxBidder = b.BidderName;
                }

            }
            return maxBidder;
        }
    }
}
