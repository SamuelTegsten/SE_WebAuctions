using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Model;

namespace WebAuctions.Persistence.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

        public DbSet<AuctionDB> AuctionDBs { get; set; }
        public DbSet<UserDB> UserDBs { get; set; }
        public DbSet<ItemDB> ItemDBs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionDB>().HasData(
                new AuctionDB
                {
                    Id = -1,
                    ItemName = "Large Tent",
                    Username = "user",
                    Duration = 3,
                    Date = DateTime.Now,
                    Status = AuctionStatus.Active,
                    Bid = 50,
                });

            modelBuilder.Entity<UserDB>().HasData(
                new UserDB
                {
                    UserId = -1,
                    Username = "user",
                    Password = "password",
                    Permission = UserRole.USER
                });


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
