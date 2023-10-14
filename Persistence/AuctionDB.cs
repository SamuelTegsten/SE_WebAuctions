using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAuctions.Core;

namespace WebAuctions.Persistence
{
    public class AuctionDB
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Item")]
        [MaxLength(128)]
        public String ItemName { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }
        public TimeSpan Duration { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [EnumDataType(typeof(AuctionStatus))]
        public AuctionStatus Status { get; set; }

        [MaxLength(128)]
        public double Bid { get; set; }

    }
}
