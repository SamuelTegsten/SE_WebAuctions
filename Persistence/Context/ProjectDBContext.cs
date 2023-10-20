using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Model;

namespace WebAuctions.Persistence.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<AuctionDB> AuctionDBs { get; set; }
        public DbSet<ItemDB> ItemDBs { get; set; }
        public DbSet<BidDB> BidDBs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDB>().HasData(
                new AuctionDB
                {
                    Id = -1,
                    ItemName = "Large Tent",
                    Auctioneer = "user",
                    OpeningPrice = 5000.50,
                    EndDate = DateTime.Now,
                    BidDBs = new List<BidDB>()
                });
            BidDB bidDB1 = new BidDB()
            {
                Id = -1,
                Bidder = "Samuel",
                Amount = 500000.00,
                Date = DateTime.Now,
                AuctionId = -1
            };
            BidDB bidDB2 = new BidDB()
            {
                Id = -2,
                Bidder = "Esteban",
                Amount = 10000000.00,
                Date = DateTime.Now,
                AuctionId = -1,
            };
            modelBuilder.Entity<BidDB>().HasData(bidDB1);
            modelBuilder.Entity<BidDB>().HasData(bidDB2);
            modelBuilder.Entity<ItemDB>().HasData(
                new ItemDB
                {
                    Picture = "images/tent1.png",
                    Name = "Large Tent",
                    Description = "A Large Tent",
                });

        }
    }
}
