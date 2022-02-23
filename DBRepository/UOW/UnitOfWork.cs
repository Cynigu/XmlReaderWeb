using DBRepository.Interfaces;
using DBRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.UOW
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
            EmployeeRepository = new EmployeeRepository(context);
            WorkRepository = new WorkRepository(context);
            FolderRepository = new FoldersRepository(context);
            AuthUserRepository = new AuthUserRepository(context);
        }

        public IEmployeeRepository EmployeeRepository { get; }

        public IWorkRepository WorkRepository { get; }

        public IFolderRepository FolderRepository { get; }

        public IAuthUserRepository AuthUserRepository { get; }

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
