using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlReader.BLL.Models.AuthModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string Name { get; set; }

        public string Email { get; set; }
        public string Vk { get; set; }
        public string NumberPhone { get; set; }
        public UserRole Role { get; set; } = UserRole.User;
        public bool RememberMe { get; set; } = true;
    }
}
