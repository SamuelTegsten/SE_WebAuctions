using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAuctions.Core.Model;

namespace WebAuctions.Persistence
{
    public class AuctionDB
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Item")]
        public String ItemName { get; set; }

        public string Username { get; set; }

        public int Duration { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [EnumDataType(typeof(AuctionStatus))]
        public AuctionStatus Status { get; set; }

        [MaxLength(128)]
        public double Bid { get; set; }

    }
}
