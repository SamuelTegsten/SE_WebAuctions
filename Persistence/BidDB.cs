using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAuctions.Persistence
{
    public class BidDB
    {
        [Key]
        public int Id { get; set; }

        public string BidderName { get; set; }   
        public decimal BidAmount { get; set; }  

        [DataType(DataType.DateTime)]
        public DateTime BidPlacedTime { get; set; }

        [ForeignKey("Auction")]
        public int AuctionId { get; set; }

        public AuctionDB Auction { get; set; }
    }
}
