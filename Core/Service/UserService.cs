using WebAuctions.Core.Interfaces.Persistence;
using WebAuctions.Core.Interfaces.Service;

namespace WebAuctions.Core.Service
{
    public class UserService : IUserService
    {
        private IUserPersistence _userPersistence;
        public UserService(IAuctionPersistence userPersistence)
        {
            userPersistence = userPersistence;
        }
    }
}
