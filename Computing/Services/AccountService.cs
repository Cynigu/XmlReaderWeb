using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;
using Models.auth;
using XmlReader.BLL.Models.AuthModels;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.Data.DBRepository.UOW;

namespace XmlReader.BLL.Service.Services
{
    public class AccountService: IAccountService
    {
        private readonly IRepositoryContextFactory _repositoryContextFactory;
        public AccountService(IRepositoryContextFactory repositoryContextFactory)
        {
            _repositoryContextFactory = repositoryContextFactory;
        }

        public UserModel? FindAccountByLoginPasswordAsync(LoginModel userAuth)
        {
            using var uow = new UnitOfWork(_repositoryContextFactory.Create());
            // Поиск пользователя по логину и паролю
            var user = uow.AuthUserRepository.GetEntityQuery()
                .FirstOrDefault(x => x.Login == userAuth.Login && x.Password == userAuth.Password);

            // если пользователь не найден
            if (user == null)
            {
                return null;
            }

            return new UserModel()
            {
                AccountId = user.Id,
                Login = user.Login,
                Role = user.Role,
                RememberMe = userAuth.RememberMe
            };
        }

        public async Task<UserModel?> RegisterAccountAsync(RegisterModel registerModel)
        {
            using var uow = new UnitOfWork(_repositoryContextFactory.Create());

            // ищем пользователя по логину
            var user = await FindAccountByLoginAsync(registerModel.Login);

            // Если пользователь найден, то регистрация не может быть проведена 
            if (user != null)
            {
                throw new AuthenticationException("Пользователь с таким логином существует");
            }
            else
            {
                // Добавляем пользователя
                await uow.AuthUserRepository.AddAsync(new AuthUserEntity()
                {
                    Login = registerModel.Login,
                    Password = registerModel.Password,
                    Role = registerModel.Role
                });
                
                // Ищем пользователя (ради Id)
                var registerUser = await FindAccountByLoginAsync(registerModel.Login);

                // Если каким-то образом созданный аккаунт не найден
                if (registerUser == null)
                {
                    throw new AuthenticationException("Что-то пошло не так!");
                }
                else
                {
                    await uow.UserProfileRepository.AddAsync(new UserProfileEntity()
                    {
                        AuthUserId = registerUser.AccountId,
                        Email = registerModel.Email,
                        Name = registerModel.Name,
                        NumberPhone = registerModel.NumberPhone,
                        Vk = registerModel.Vk
                    });

                    return new UserModel()
                    {
                        Login = registerModel.Login,
                        AccountId = registerUser.AccountId,
                        RememberMe = registerModel.RememberMe,
                        Role = registerUser.Role
                    };
                }
            }
        }

        public async Task<UserModel?> FindAccountByLoginAsync(string login)
        {
            using var uow = new UnitOfWork(_repositoryContextFactory.Create());
            var user = await uow.AuthUserRepository.GetEntityQuery().FirstOrDefaultAsync(x => x.Login == login);
            if (user == null)
            {
                return null;
            }
            else
            {
                return new UserModel()
                {
                    Login = user.Login,
                    Role = user.Role,
                    AccountId = user.Id,
                    RememberMe = true
                };
            }
        }
    }
}
