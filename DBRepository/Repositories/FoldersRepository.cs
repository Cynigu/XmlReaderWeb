using DBRepository;
using Models;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories
{
    public class FoldersRepository : DataBaseRepository<FolderEntity, RepositoryContext>, IFolderRepository
    {
        public FoldersRepository(RepositoryContext context) : base(context)
        {
        }
    }

    public class ImageRepository : DataBaseRepository<ImageEntity, RepositoryContext>, IImageRepository
    {
        public ImageRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
