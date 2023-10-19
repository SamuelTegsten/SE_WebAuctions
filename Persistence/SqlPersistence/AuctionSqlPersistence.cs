using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Model;
using WebAuctions.Persistence.Context;
using WebAuctions.ViewModels;

namespace WebAuctions.Persistence.SqlPersistence
{
    public class AuctionSqlPersistence : IAuctionPersistence
    {
        private ProjectDbContext _dbContext;
        public AuctionSqlPersistence(ProjectDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDBs.Where(p => true).ToList();
            List<Auction> result = new List<Auction>();
            foreach (AuctionDB act in auctionDbs)
            {
                var auction = new Auction(
                    act.Id,
                    GetItem(act.ItemName),
                    act.Duration,
                    act.Date,
                    act.Bid,
                    act.Username
                    );
                result.Add(auction);
            }
            return result;
        }

        public Auction GetAuctionById(int id)
        {
            var auctionDb = _dbContext.AuctionDBs.FirstOrDefault(a => a.Id == id);

            if (auctionDb != null)
            {
                var auction = new Auction(
                    auctionDb.Id,
                    GetItem(auctionDb.ItemName),
                    auctionDb.Duration,
                    auctionDb.Date,
                    auctionDb.Bid,
                    auctionDb.Username
                );

                return auction;
            }
            throw new InvalidOperationException("Auction not found");
        }

        public List<Auction> GetAuctionsByName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDBs.Where(a => a.Username == userName).ToList();
            var result = new List<Auction>();

            foreach (var auctionDb in auctionDbs)
            {
                var auction = new Auction(
                    auctionDb.Id,
                    GetItem(auctionDb.ItemName),
                    auctionDb.Duration,
                    auctionDb.Date,
                    auctionDb.Bid,
                    auctionDb.Username
                );

                result.Add(auction);
            }

            return result;
        }

        private Item GetItem(string ItemName)
        {
            var itemDb = _dbContext.ItemDBs.FirstOrDefault(i => i.Name == ItemName);

            if (itemDb != null)
            {
                var item = new Item(itemDb.Picture, itemDb.Name, itemDb.Description);
                return item;
            }
            return null; 
        }
    }
}
