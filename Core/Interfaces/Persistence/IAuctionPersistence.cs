﻿using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Persistence
{
    public interface IAuctionPersistence
    {
        public List<Auction> GetAll();
        public List<Auction> GetUsersOngoingAuctions(string username, DateTime now);
        public List<Auction> GetUsersWonAuctions(string username, DateTime now);
        public Auction GetAuctionById(int id);
        public List<Auction> GetAuctionByUserName(string auctioneer);
        public int DeleteAuctionById(int id);
        public List<Auction> GetAuctionsByName(string UserName);
        public int AddAuction(Auction Auction);
    }
}
