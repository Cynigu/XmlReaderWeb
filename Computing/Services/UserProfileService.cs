using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Factories;
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
                // Запоминаем логин и пароль
                userInfo.Login = account.Login;
                userInfo.Password = account.Password;

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
    }
}
