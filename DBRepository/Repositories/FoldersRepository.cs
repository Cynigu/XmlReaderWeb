using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    public class FoldersRepository : TEntityRepository<Folder, RepositoryContext>, IFolderRepository
    {
        public FoldersRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
