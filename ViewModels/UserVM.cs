using WebAuctions.Core.Model;

namespace WebAuctions.ViewModels
{
    public class UserVM
    {
        public string Username { get; set; }
        public UserRole Permission { get; set; }

        public static UserVM FromUser(User user)
        {
            return new UserVM()
            {
                Username = user.Username,
                Permission = user.Permission,
        };
        }
    }
}
