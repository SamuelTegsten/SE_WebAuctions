namespace WebAuctions.Core.Model
{
    public class Item
    {
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Item(string picture, string name, string description)
        {

            this.Picture = picture;
            this.Name = name;
            this.Description = description;
        }

        public Item()
        {
            // Default constructor with no parameters
        }
    }
}
