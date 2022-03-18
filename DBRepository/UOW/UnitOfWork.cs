using DBRepository;
using XmlReader.Data.DBRepository.Interfaces;
using XmlReader.Data.DBRepository.Repositories;

namespace XmlReader.Data.DBRepository.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        protected readonly RepositoryContext _repositoryContext;
        public UnitOfWork(RepositoryContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            _repositoryContext = context;
            UserProfileRepository = new UserProfileRepository(context);
            ProjectRepository = new ProjectRepository(context);
            FolderRepository = new FoldersRepository(context);
            AuthUserRepository = new AuthUserRepository(context);
            WorkspaceRepository = new WorkspaceRepository(context);
            ImageRepository = new ImageRepository(context);
        }

        public IUserProfileRepository UserProfileRepository { get; }

        public IProjectRepository ProjectRepository { get; }

        public IFolderRepository FolderRepository { get; }

        public IAuthUserRepository AuthUserRepository { get; }
        public IWorkspaceRepository WorkspaceRepository { get; }
        public IImageRepository ImageRepository { get; }

        private bool disposed = false;
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repositoryContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
