using System.ComponentModel.DataAnnotations;

namespace XmlReader.BLL.Models.AuthModels;

public class UserModel
{
    /// <summary>
    /// Id из таблицы AuthUserEntity 
    /// </summary>
    public int AccountId { get; set; }
    public string Login { get; set; }
    public string Role { get; set; } = "user";
    public bool RememberMe { get; set; } = true;
}