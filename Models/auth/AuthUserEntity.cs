using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.auth
{
    public enum UserRole
    {
        Admin,
        User
    }
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public UserProfileEntity UserProfile { get; set; }
    }
}
