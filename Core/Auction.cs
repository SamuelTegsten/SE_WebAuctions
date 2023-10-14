namespace WebAuctions.Core
{
    public class Auction
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
        public AuctionStatus Status { get; set; }
        public double Bid { get; set; }
        public string Username { get; set; }

        public Auction(Item item, TimeSpan duration, DateTime date, double bid, string username)
        {
            Item = item;
            Duration = duration;
            Date = date;
            Status = AuctionStatus.Active; 
            Bid = bid;
            Username = username;
        }
    }
}
