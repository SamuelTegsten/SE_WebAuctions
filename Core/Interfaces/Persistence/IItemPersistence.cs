using WebAuctions.Core.Model;

namespace WebAuctions.Core.Interfaces.Persistence
{
    public interface IItemPersistence
    {
        bool AddItem(Item item);
        bool UpdateDescription(Item item, string newDescription);
    }
}
