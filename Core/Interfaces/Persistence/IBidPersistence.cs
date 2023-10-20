using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Persistence
{
    public interface IBidPersistence
    {
        bool addBid(Bid bid);
    }
}
