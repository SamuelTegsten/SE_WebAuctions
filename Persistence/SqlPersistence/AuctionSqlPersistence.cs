using System.Security.Cryptography;
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

        public int AddAuction(Auction auction)
        {
            try
            {
                var auctionDB = new AuctionDB
                {
                    ItemName = auction.Item.Name,
                    AuctionName = auction.AuctionName,
                    Date = auction.Date,
                    ExpirationDate = auction.ExpirationDate,
                };

                _dbContext.AuctionDBs.Add(auctionDB);
                _dbContext.SaveChanges();

                return auctionDB.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add auction", ex);
            }
        }

        public List<Auction> GetAll()
        {
            var auctionDbs = _dbContext.AuctionDBs
                .Include(a => a.Bids)
                .ToList();

            List<Auction> result = new List<Auction>();

            foreach (AuctionDB act in auctionDbs)
            {
                Item item = GetItem(act.ItemName); 

                var auction = new Auction(
                    act.Id,
                    item,
                    act.ExpirationDate,
                    act.Date,
                    act.Bids.Select(b => new Bid(b.Id, b.BidderName, b.BidAmount, b.BidPlacedTime)).ToList(), 
                    act.AuctionName 
                );

                result.Add(auction);
            }

            return result;
        }


        public Auction GetAuctionById(int id)
        {
            var auctionDb = _dbContext.AuctionDBs
                .Include(a => a.Bids)
                .FirstOrDefault(a => a.Id == id);

            if (auctionDb != null)
            {
                Item item = GetItem(auctionDb.ItemName); 

                var auction = new Auction(
                    auctionDb.Id,
                    item,
                    auctionDb.ExpirationDate,
                    auctionDb.Date,
                    auctionDb.Bids.Select(b => new Bid(b.Id, b.BidderName, b.BidAmount, b.BidPlacedTime)).ToList(), 
                    auctionDb.AuctionName 
                );

                return auction;
            }

            throw new InvalidOperationException("Auction not found");
        }


        public List<Auction> GetAuctionsByName(string userName)
        {
            var auctionDbs = _dbContext.AuctionDBs
                .Include(a => a.Bids)
                .Where(a => a.Bids.Any(b => b.BidderName == userName))
                .ToList();

            var result = new List<Auction>();

            foreach (var auctionDb in auctionDbs)
            {
                Item item = GetItem(auctionDb.ItemName); 

                var auction = new Auction(
                    auctionDb.Id,
                    item,
                    auctionDb.ExpirationDate,
                    auctionDb.Date,
                    auctionDb.Bids.Select(b => new Bid(b.Id, b.BidderName, b.BidAmount, b.BidPlacedTime)).ToList(), 
                    auctionDb.AuctionName 
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
