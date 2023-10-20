using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Service
{
    public interface IBidService
    {
        bool addBid(Bid bid);
    }
}
