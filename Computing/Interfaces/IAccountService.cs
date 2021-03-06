using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlReader.BLL.Models.AuthModels;
using XmlReader.BLL.Models.Models;

namespace XmlReader.BLL.Service.Interfaces
{
    public interface IAccountService
    {
        UserModel? FindAccountByLoginPasswordAsync(LoginModel userAuth);
        Task<UserModel?> RegisterAccountAsync(RegisterModel registerModel);
        Task<UserModel?> FindAccountByLoginAsync(string login);
    }
}
