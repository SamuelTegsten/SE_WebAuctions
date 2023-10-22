using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Service
{
    public interface IAuctionService
    {
        List<Auction> GetAll();
        Auction GetAuctionById(int id);
        List<Auction> GetAuctionsByName(string UserName);
        public List<Auction> GetAuctionByUserName(string auctioneer);
        int AddAuction(Auction Auction);
        public int DeleteAuctionById(int id);

    }
}
