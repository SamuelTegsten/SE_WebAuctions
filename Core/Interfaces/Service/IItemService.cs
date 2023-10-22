using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Service
{
    public interface IItemService
    {
        bool AddItem(Item item);
        bool UpdateDescription(string itemName, string newDescription);
    }
}
