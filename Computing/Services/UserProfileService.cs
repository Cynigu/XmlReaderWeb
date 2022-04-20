using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Factories;
using Microsoft.EntityFrameworkCore;
using XmlReader.BLL.Models.Models;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.Data.DBRepository.Interfaces;
using XmlReader.Data.DBRepository.UOW;

namespace XmlReader.BLL.Service.Services
{
    public class UserProfileService: IUserProfileService
    {
        private readonly IRepositoryContextFactory _repositoryContextFactory;
        public UserProfileService(IRepositoryContextFactory repositoryContextFactory)
        {
            _repositoryContextFactory = repositoryContextFactory;
        }

        public UserInfo GetUserInfoByLogin(string login)
        {
            UserInfo userInfo = new UserInfo();
            using (var uow = new UnitOfWork(_repositoryContextFactory.Create()))
            {
                // Получаем аккаунт с данным логином
                var account = uow.AuthUserRepository.GetEntityQuery().FirstOrDefault(x => x.Login == login);

                //Если никто не найден с таким логином
                if (account == null)
                {
                    throw new ArgumentException("Никого с таким логином не найдено");
                }

                // Запоминаем логин и пароль и роль
                userInfo.Login = account.Login;
                userInfo.Password = account.Password;
                userInfo.Role = account.Role;

                // По id аккаунта находим профиль пользователя 
                var profile = uow.UserProfileRepository.GetEntityQuery().FirstOrDefault(x => x.AuthUserId == account.Id);
                if (profile == null)
                {
                    userInfo.Email = null;
                    userInfo.Name = null;
                    userInfo.NumberPhone = null;
                    userInfo.Vk = null;
                }
                else
                {
                    userInfo.Email = profile.Email;
                    userInfo.Name = profile.Name;
                    userInfo.NumberPhone = profile.NumberPhone;
                    userInfo.Vk = profile.Vk;
                }
            }

            return userInfo;
        }

        public async Task<ICollection<UserInfo>> GetUsersInfosByLoginAsync(string searchStr)
        {
            ICollection<UserInfo> users;
            using (var uow = new UnitOfWork(_repositoryContextFactory.Create()))
            {
                var accounts = uow.AuthUserRepository.GetEntityQuery()
                    .Where(x => x.Login.Contains(searchStr))
                    .Select(user => new UserInfo()
                    {
                        Login = user.Login,
                        Role = user.Role,
                        Password = user.Password,
                        Name = user.UserProfile.Name,
                        NumberPhone = user.UserProfile.NumberPhone,
                        Vk = user.UserProfile.Vk,
                        Email = user.UserProfile.Email
                    });
                users = await accounts.ToListAsync();
            }

            return users;
        }

        public async Task DeleteUserByLoginAsync(string login)
        {
            using (var uow = new UnitOfWork(_repositoryContextFactory.Create()))
            {
                var user = uow.AuthUserRepository.GetEntityQuery().FirstOrDefault(x => x.Login == login);
                if (user == null)
                    throw new ArgumentException("Пользователя с таким логином не существует");
                if (user.Role == "admin")
                    throw new Exception("Нельзя удалить профиль админа");
                await uow.AuthUserRepository.RemoveRangeAsync(x => x.Login == login);
            }
        }
    }
}
