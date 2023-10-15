using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebAuctions.Core.Model;

namespace WebAuctions.Persistence
{
    public class UserDB
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        [EnumDataType(typeof(UserRole))]
        public UserRole Permission
        {
            get; set;
        }
    }
}
