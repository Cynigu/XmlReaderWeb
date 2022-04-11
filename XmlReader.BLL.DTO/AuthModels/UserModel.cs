using System.ComponentModel.DataAnnotations;

namespace XmlReader.BLL.Models.AuthModels;

public class UserModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Role { get; set; } = "user";
    public bool RememberMe { get; set; } = true;
}