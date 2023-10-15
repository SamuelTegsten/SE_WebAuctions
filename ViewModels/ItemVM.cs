using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
    public class ItemVM
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static ItemVM FromItem(Item item)
        {
            return new ItemVM()
            {
                Picture = item.Picture,
                Name = item.Name,
                Description = item.Description
            };
        }
    }
}
