using DBRepository;
using Models;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories
{
    public class UserProfileRepository : DataBaseRepository<UserProfileEntity, RepositoryContext>, IUserProfileRepository
    {
        public UserProfileRepository(RepositoryContext context) : base(context)
        {
        }

    }
}
