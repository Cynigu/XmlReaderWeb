using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Factories;
using XmlReader.BLL.Models.AuthModels;
using XmlReader.BLL.Service.Interfaces;
using XmlReader.Data.DBRepository.UOW;

namespace XmlReader.BLL.Service.Services
{
    public class AccountService: IAccountService
    {
        private IRepositoryContextFactory _repositoryContextFactory;
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
            throw new NotImplementedException();
        }

        public async Task<UserModel?> FindAccountByLoginAsync(string login)
        {
            throw new NotImplementedException();
        }
    }
}
