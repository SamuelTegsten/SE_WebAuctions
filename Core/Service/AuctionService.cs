using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;

namespace WebAuctions.Core.Service
{
    public class AuctionService : IAuctionService
    {
        private IAuctionPersistence _auctionPersistence;
        public AuctionService(IAuctionPersistence auctionPersistence)
        {
            _auctionPersistence = auctionPersistence;
        }

        public int AddAuction(Auction Auction)
        {
            return _auctionPersistence.AddAuction(Auction);
        }

        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public List<Auction> GetUsersOngoingAuctions(string username, DateTime now)
        {
            return _auctionPersistence.GetUsersOngoingAuctions(username, now);
        }

        public List<Auction> GetUsersWonAuctions(string username, DateTime now)
        {
            return _auctionPersistence.GetUsersWonAuctions(username, now);
        }

        public List<Auction> GetAuctionByUserName(string auctioneer)
        {
            return _auctionPersistence.GetAuctionByUserName(auctioneer);
        }


        public Auction GetAuctionById(int id)
        {
            return _auctionPersistence.GetAuctionById(id);
        }

        public List<Auction> GetAuctionsByName(string UserName)
        {
            return _auctionPersistence.GetAuctionsByName(UserName);
        }

        public int DeleteAuctionById(int id)
        {
            return _auctionPersistence.DeleteAuctionById(id);
        }


    }
}
