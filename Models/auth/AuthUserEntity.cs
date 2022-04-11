using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.auth
{
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "user";
        public UserProfileEntity UserProfile { get; set; }
    }
}
