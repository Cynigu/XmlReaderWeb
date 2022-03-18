using DBRepository;
using Models.auth;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories;

public class AuthUserRepository : DataBaseRepository<AuthUserEntity, RepositoryContext>, IAuthUserRepository
{
    public AuthUserRepository(RepositoryContext context) : base(context)
    {
    }

}