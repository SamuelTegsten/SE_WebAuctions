using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Model;
using WebAuctions.Persistence.Context;

namespace WebAuctions.Persistence.SqlPersistence
{
    public class ItemSqlPersistence : IItemPersistence
    {
        private ProjectDbContext _dbContext;
        public ItemSqlPersistence(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddItem(Item item)
        {
            try
            {
                var itemDB = new ItemDB
                {
                    Name = item.Name,
                    Picture = item.Picture,
                    Description = item.Description
                };

                _dbContext.ItemDBs.Add(itemDB);
                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add item", ex);
            }
        }

        public bool UpdateDescription(Item item, string newDescription)
        {
            try
            {
                var existingItem = _dbContext.ItemDBs.FirstOrDefault(i => i.Name == item.Name);

                if (existingItem != null)
                {
                    existingItem.Description = newDescription;
                    _dbContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to update item description", ex);
            }

        }
    }
}