using System;
using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
	public class BidVM
    {
        public int Id { get; set; }
        public string Bidder { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public static BidVM FromBid(Bid bid)
        {
            return new BidVM()
            {
                Id = bid.Id,
                Bidder = bid.Bidder,
                Amount = bid.Amount,
                Date = bid.Date
            };
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }



}

