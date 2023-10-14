using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebAuctions.Core;

namespace WebAuctions.Persistence
{
    public class UserDB
    {
        [Key]
        public string Username { get; set; }

        [Index(IsUnique = true)]
        public string Password { get; set; }

        [EnumDataType(typeof(UserRole))]
        public UserRole Permission
        {
            get; set;
        }
    }
}
