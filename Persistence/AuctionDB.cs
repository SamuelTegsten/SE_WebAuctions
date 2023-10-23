using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebAuctions.Core.Model;

namespace WebAuctions.Persistence
{
    public class AuctionDB
    {
        [Key]
        public int Id { get; set; }

        public string Auctioneer { get; set; }

        [ForeignKey("Item")]
        public String ItemName { get; set; }

        public string AuctionName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ExpirationDate { get; set; }

        public ItemDB Item { get; set; }

        [InverseProperty("Auction")] 
        public List<BidDB> Bids { get; set; }
    }
}
