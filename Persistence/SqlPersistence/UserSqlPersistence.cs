using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Persistence.Context;

namespace WebAuctions.Persistence.SqlPersistence
{
    public class UserSqlPersistence : IUserPersistence
    {
        private ProjectDbContext _dbContext;
        public UserSqlPersistence(ProjectDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
