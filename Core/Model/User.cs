namespace WebAuctions.Core.Model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Permission { get; set; }

        public User(string username, string password, UserRole permission)
        {
            Username = username;
            Password = password;
            Permission = permission;
        }
    }
}
