using DBRepository.Interfaces;
using Models.auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repositories
{
    public class AuthUserRepository : TEntityRepository<AuthUser, RepositoryContext>, IAuthUserRepository
    {
        public AuthUserRepository(RepositoryContext context) : base(context)
        {
        }

    }
}
