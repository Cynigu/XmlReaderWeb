using System.ComponentModel.DataAnnotations;

namespace XmlReader.BLL.Models.AuthModels
{
    public enum UserRole
    {
        User, Admin
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; } = true;
    }
}
