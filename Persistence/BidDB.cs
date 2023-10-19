using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using WebAuctions.Core.Model;

namespace WebAuctions.Persistence
{
	public class BidDB
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Bidder { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [ForeignKey("AuctionId")]
        public AuctionDB AuctionDB { get; set; }

        public int AuctionId { get; set; }



    }
}

