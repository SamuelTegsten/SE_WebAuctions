using System;
namespace WebAuctions.ViewModels
{
    public class AccountVM
    {
        public List<AuctionVM> Current { get; set; }
        public List<AuctionVM> Won { get; set; }

    }
}

