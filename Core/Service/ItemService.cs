using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;
using WebAuctions.Core.Model;

namespace WebAuctions.Core.Service
{
    public class ItemService : IItemService
    {
        private IItemPersistence _itemPersistence;
        public ItemService(IItemPersistence itemPersistence)
        {
            _itemPersistence = itemPersistence;
        }

        public bool AddItem(Item item)
        {
            return _itemPersistence.AddItem(item);
        }

        public bool UpdateDescription(string itemName, string newDescription)
        {
            return _itemPersistence.UpdateDescription(itemName, newDescription);
        }
    }
}
