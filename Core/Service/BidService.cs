using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;

namespace WebAuctions.Core.Service
{
    public class BidService : IBidService
    {
        private IBidPersistence _bidPersistence;
        public BidService(IBidPersistence bidPersistence)
        {
            _bidPersistence = bidPersistence;
        }

        public bool addBid(Bid bid)
        {
            return _bidPersistence.addBid(bid);
        }
    }
}
