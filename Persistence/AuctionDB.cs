using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAuctions.Core.Model;

namespace WebAuctions.Persistence
{
    public class AuctionDB
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Item")]
        public string ItemName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Auctioneer { get; set; }

        [Required]
        public double OpeningPrice { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }

        public ItemDB Item { get; set; } // Navigation property
      
        public List<BidDB> BidDBs { get; set; } = new List<BidDB>();

    }
}
