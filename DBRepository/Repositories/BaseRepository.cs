using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBRepository.Repositories
{
    public abstract class BaseRepository
    {
        protected RepositoryContext _repositoryContext { get; }
		public BaseRepository(RepositoryContext context)
        {
            _repositoryContext = context;
        }
    }
}
