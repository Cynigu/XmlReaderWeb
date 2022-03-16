using DBRepository;
using Models.auth;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories.auth
{
    public class AuthUserRepository : DataBaseRepository<AuthUser, RepositoryContext>, IAuthUserRepository
    {
        public AuthUserRepository(RepositoryContext context) : base(context)
        {
        }

    }
}
