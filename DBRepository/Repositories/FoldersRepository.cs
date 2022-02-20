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

        public async Task ChangeAsync(int id, Folder item)
        {
            Folder? entity = await _repositoryContext.Folders.FindAsync(id);
            if (entity != null)
            {
                entity.CountXmlFiles = item.CountXmlFiles;
                entity.CountFiles = item.CountFiles;
                entity.CountObject = item.CountObject;
                entity.PathFolder = item.PathFolder;
            }
            await SaveAsync();
        }
    }
}
