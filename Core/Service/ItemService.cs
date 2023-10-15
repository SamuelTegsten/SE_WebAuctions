using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;

namespace WebAuctions.Core.Service
{
    public class ItemService : IItemService
    {
        private IItemPersistence _itemPersistence;
        public ItemService(IItemPersistence itemPersistence)
        {
            _itemPersistence = itemPersistence;
        }
    }
}
