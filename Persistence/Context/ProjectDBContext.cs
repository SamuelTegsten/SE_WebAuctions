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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BidDB>()
                .Property(b => b.BidAmount)
                .HasColumnType("decimal(18, 2)"); 

            modelBuilder.Entity<AuctionDB>().HasData(
                new AuctionDB
                {
                    Id = -1,
                    ItemName = "testItem",
                    ExpirationDate = DateTime.Now.AddDays(3),
                    Date = DateTime.Now,
                    AuctionName = "user",
                });
        }
    }
}
