using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Model;
using WebAuctions.Persistence.Context;
using WebAuctions.ViewModels;

namespace WebAuctions.Persistence.SqlPersistence
{
    public class BidSqlPersistence : IBidPersistence
    {
        private ProjectDbContext _dbContext;

        public BidSqlPersistence(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool addBid(Bid bid)
        {
            try
            {
                {
                    var newBid = new BidDB
                    {
                        BidAmount = bid.BidAmount,
                        BidderName = bid.BidderName,
                        BidPlacedTime = bid.BidPlacedTime,
                        AuctionId = bid.Id
                    };
                    _dbContext.BidDBs.Add(newBid);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add bid", ex);
            }
        }
    }
}
