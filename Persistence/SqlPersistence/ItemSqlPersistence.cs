using WebAuctions.Core.Interfaces.Persistence;
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
    }
}
