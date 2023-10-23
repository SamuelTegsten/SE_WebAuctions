using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Model;
using WebAuctions.Persistence.Context;
using WebAuctions.ViewModels;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebAuctions.Persistence.SqlPersistence
{
    public class BidSqlPersistence : IBidPersistence
    {
        private UnitOfWork _unitOfWork;

        public BidSqlPersistence(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool addBid(Bid bid)
        {
            try
            {
                var newBid = new BidDB
                {
                    BidAmount = bid.BidAmount,
                    BidderName = bid.BidderName,
                    BidPlacedTime = bid.BidPlacedTime,
                    AuctionId = bid.Id
                };

                _unitOfWork.BidRepository.Insert(newBid);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add bid", ex);
            }
        }
    }
}
