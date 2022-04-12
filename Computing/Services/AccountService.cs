using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var user = uow.AuthUserRepository.GetEntityQuery()
                .FirstOrDefault(x => x.Login == userAuth.Login && x.Password == userAuth.Password);

            if (user == null)
            {
                return null;
            }

            return new UserModel()
            {
                Id = user.Id,
                Login = user.Login,
                Role = user.Role,
                RememberMe = userAuth.RememberMe
            };
        }

        public async Task<UserModel?> RegisterAccountAsync(RegisterModel registerModel)
        {
            using var uow = new UnitOfWork(_repositoryContextFactory.Create());
            var user = await FindAccountByLoginAsync(registerModel.Login);
            if (user != null)
            {
                throw new AuthenticationException("Пользователь с таким логином существует");
            }
            else
            {
                await uow.AuthUserRepository.AddAsync(new AuthUserEntity()
                {
                    Login = registerModel.Login,
                    Password = registerModel.Password,
                    Role = registerModel.Role
                });

                var registerUser = await FindAccountByLoginAsync(registerModel.Login);

                if (registerUser == null)
                {
                    throw new AuthenticationException("Что-то пошло не так!");
                }
                else
                {
                    return new UserModel()
                    {
                        Login = registerModel.Login,
                        Id = registerUser.Id,
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
                    Id = user.Id,
                    RememberMe = true
                };
            }
            
        }
    }
}
