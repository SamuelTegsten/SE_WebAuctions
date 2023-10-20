using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Persistence
{
    public interface IAuctionPersistence
    {
        public List<Auction> GetAll();
        public Auction GetAuctionById(int id);
        List<Auction> GetAuctionsByName(string UserName);
        int AddAuction(Auction Auction);
    }
}
