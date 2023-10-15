namespace WebAuctions.Core.Model
{
    public class Auction
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public AuctionStatus Status { get; set; }
        public double Bid { get; set; }
        public string Username { get; set; }

        public Auction(int Id, Item item, int duration, DateTime date, double bid, string username)
        {
            this.Id = Id;
            this.Item = item;
            this.Duration = duration;
            this.Date = date;
            this.Status = AuctionStatus.Active;
            this.Bid = bid;
            this.Username = username;
        }
    }
}
