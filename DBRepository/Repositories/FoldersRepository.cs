using DBRepository;
using Models;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories
{
    public class FoldersRepository : DataBaseRepository<Folder, RepositoryContext>, IFolderRepository
    {
        public FoldersRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
