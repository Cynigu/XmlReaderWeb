using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlReader.BLL.Models.Models;

namespace XmlReader.BLL.Service.Interfaces
{
    public interface IUserProfileService
    {
        UserInfo GetUserInfoByLogin(string login);
        Task<ICollection<UserInfo>> GetUsersInfosByLoginAsync(string searchStr);
    }
}
