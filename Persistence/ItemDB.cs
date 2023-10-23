using System.ComponentModel.DataAnnotations;

namespace WebAuctions.Persistence
{
    public class ItemDB
    {
        public string Picture { get; set; }

        [Key]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        public ItemDB()
        {
        }

        [Obsolete]
        public ItemDB(string picture, string name, string description)
        {
            Picture = picture;
            Name = name;
            Description = description;
        }

    }


}
