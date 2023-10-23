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
        private UnitOfWork _unitOfWork;
        public AuctionSqlPersistence(ProjectDbContext dbContext, UnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
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
                    Auctioneer = auction.Auctioneer,
                };

                _unitOfWork.AuctionRepository.Insert(auctionDB);
                _unitOfWork.Save();

                return auctionDB.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add auction", ex);
            }
        }

        public List<Auction> GetUsersOngoingAuctions(string username, DateTime now)
        {
            var auctionDbs = _unitOfWork.AuctionRepository.Get(
                filter: a => a.ExpirationDate > now && a.Bids.Any(b => b.BidderName == username),
                includeProperties: "Bids"
            );

            List<Auction> result = new List<Auction>();
            foreach (AuctionDB act in auctionDbs)
            {
                Item item = GetItem(act.ItemName);
                var auction = new Auction(
                    act.Id,
                    act.Auctioneer,
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
        public List<Auction> GetUsersWonAuctions(string username, DateTime now)
        {
            var auctions = _unitOfWork.AuctionRepository.Get(
                filter: a => a.ExpirationDate <= now,
                includeProperties: "Bids"
            );

            var result = auctions
                .Where(a => a.Bids.Any(b => b.BidderName == username && b.BidAmount == a.Bids.Max(maxBid => maxBid.BidAmount)))
                .Select(auctionDB => new Auction(
                    auctionDB.Id,
                    auctionDB.Auctioneer,
                    GetItem(auctionDB.ItemName),
                    auctionDB.ExpirationDate,
                    auctionDB.Date,
                    auctionDB.Bids.Select(b => new Bid(b.Id, b.BidderName, b.BidAmount, b.BidPlacedTime)).ToList(),
                    auctionDB.AuctionName
                ))
                .ToList();

            return result;
        }

        public List<Auction> GetAll()
        {
            var auctions = _unitOfWork.AuctionRepository.Get(includeProperties: "Bids");
            var result = new List<Auction>();

            foreach (var auctionDb in auctions)
            {
                Item item = GetItem(auctionDb.ItemName);

                var auction = new Auction(
                    auctionDb.Id,
                    auctionDb.Auctioneer,
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


        public int DeleteAuctionById(int id)
        {
            var auction = _unitOfWork.AuctionRepository.GetByID(id);
            if (auction != null)
            {
                _unitOfWork.AuctionRepository.Delete(auction);
                _unitOfWork.Save();
            }

            return id;
        }

        public List<Auction> GetAuctionByUserName(string auctioneer)
        {
            var auctions = _unitOfWork.AuctionRepository.Get(
                filter: a => a.Auctioneer == auctioneer,
                includeProperties: "Bids"
            );

            if (auctions != null)
            {
                List<Auction> result = new List<Auction>();
                foreach (AuctionDB act in auctions)
                {
                    Item item = GetItem(act.ItemName);

                    var auction = new Auction(
                        act.Id,
                        act.Auctioneer,
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

            throw new InvalidOperationException("Auction not found");
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
                    auctionDb.Auctioneer,
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
            var auctions = _unitOfWork.AuctionRepository.Get(
                filter: a => a.Bids.Any(b => b.BidderName == userName),
                includeProperties: "Bids"
            );

            var result = new List<Auction>();

            foreach (var auctionDb in auctions)
            {
                Item item = GetItem(auctionDb.ItemName);

                var auction = new Auction(
                    auctionDb.Id,
                    auctionDb.Auctioneer,
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
