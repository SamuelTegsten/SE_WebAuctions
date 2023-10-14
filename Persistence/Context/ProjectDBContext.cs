using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebAuctions.Core;

namespace WebAuctions.Persistence.Context
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }

        public DbSet<AuctionDB> auctionDBs { get; set; }
        public DbSet<UserDB> UserDBs { get; set; }
        public DbSet<ItemDB> ItemDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDB>().HasData(
                new AuctionDB
                {
                    Id = -1,
                    ItemName = "start",
                    Username = "start",
                    Duration = TimeSpan.FromSeconds(0),
                    Date = DateTime.Now,
                    Status = AuctionStatus.Completed,
                    Bid = 0,
                });
        }
    }
}
