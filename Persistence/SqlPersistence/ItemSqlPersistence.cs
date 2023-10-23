using Microsoft.EntityFrameworkCore;
using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Model;
using WebAuctions.Persistence.Context;
using System;
using System.Linq;

namespace WebAuctions.Persistence.SqlPersistence
{
    public class ItemSqlPersistence : IItemPersistence
    {
        private ProjectDbContext _dbContext;
        private UnitOfWork _unitOfWork;

        public ItemSqlPersistence(ProjectDbContext dbContext, UnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
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

                _unitOfWork.ItemRepository.Insert(itemDB);
                _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add item", ex);
            }
        }

        public bool UpdateDescription(string itemName, string newDescription)
        {
            try
            {
                var existingItem = _unitOfWork.ItemRepository.Get(filter: i => i.Name == itemName).FirstOrDefault();

                if (existingItem != null)
                {
                    existingItem.Description = newDescription;
                    _unitOfWork.Save();
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
