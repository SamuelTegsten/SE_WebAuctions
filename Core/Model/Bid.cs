using System;
namespace WebAuctions.Core.Model
{
	public class Bid
	{
		public int Id { get; set; }
		public string Bidder { get; set; }
		public double Amount { get; set; }
		DateTime _date;
		public DateTime Date { get => _date; }

		public Bid(int id, string bidder, double amount)
		{
			Id = id;
			Bidder = bidder;
			Amount = amount;
			_date = DateTime.Now;
		}

        public Bid(int id, string bidder, double amount, DateTime date) : this(id, bidder, amount)
        {
            _date = date;
        }
    }
}

