using System;
using WebAuctions.Core.Model;
using WebAuctions.Persistence.Context;

namespace WebAuctions.Persistence
{
    public class UnitOfWork : IDisposable
    {
        private ProjectDbContext context;

        public UnitOfWork(ProjectDbContext context)
        {
            this.context = context;
        }

        private GenericRepository<AuctionDB> auctionRepository;
        private GenericRepository<BidDB> bidRepository;
        private GenericRepository<ItemDB> itemRepository;

        public GenericRepository<AuctionDB> AuctionRepository
        {
            get
            {
                if (this.auctionRepository == null)
                {
                    this.auctionRepository = new GenericRepository<AuctionDB>(context);
                }
                return auctionRepository;
            }
        }

        public GenericRepository<BidDB> BidRepository
        {
            get
            {
                if (this.bidRepository == null)
                {
                    this.bidRepository = new GenericRepository<BidDB>(context);
                }
                return bidRepository;
            }
        }

        public GenericRepository<ItemDB> ItemRepository
        {
            get
            {
                if (this.itemRepository == null)
                {
                    this.itemRepository = new GenericRepository<ItemDB>(context);
                }
                return itemRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
