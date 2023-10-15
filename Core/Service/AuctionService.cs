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
        public List<Auction> GetAll()
        {
            return _auctionPersistence.GetAll();
        }

        public Auction GetAuctionById(int id)
        {
            return _auctionPersistence.GetAuctionById(id);
        }
    }
}
