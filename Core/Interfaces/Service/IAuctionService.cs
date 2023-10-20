 using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Service
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        Auction GetAuctionById(int id);
        List<Auction> GetAuctionsByName(string UserName);
    }
}
