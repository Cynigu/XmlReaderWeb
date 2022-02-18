using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    public class FoldersRepository : TEntityRepository<Folder>, IFolderRepository
    {
        public FoldersRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
