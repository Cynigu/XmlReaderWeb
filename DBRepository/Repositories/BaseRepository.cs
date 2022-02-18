using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DBRepository.Repositories
{
    public abstract class BaseRepository
    {
        //protected string _connectionString { get; }
        protected RepositoryContext _repositoryContext { get; }
		//protected IRepositoryContextFactory ContextFactory { get; }
		public BaseRepository(RepositoryContext context)
        {
            //_connectionString = connectionString;
            _repositoryContext = context;
			//ContextFactory = contextFactory;
        }
    }
}
