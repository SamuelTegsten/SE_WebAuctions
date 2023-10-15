namespace WebAuctions.Core.Model
{
    public class Item
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string picture, string name, string description)
        {

            Picture = picture;
            Name = name;
            Description = description;
        }
    }
}
