using System;

namespace WebAuctions.Core.Model
{
    public class Bid
    {
        public int Id { get; set; }
        public string BidderName { get; set; }    
        public decimal BidAmount { get; set; }    
        public DateTime BidPlacedTime { get; set; }  

        public Bid(int id, string bidderName, decimal bidAmount, DateTime bidPlacedTime)
        {
            this.Id = id;
            this.BidderName = bidderName;
            this.BidAmount = bidAmount;
            this.BidPlacedTime = bidPlacedTime;
        }
    }
}

