using DBRepository;
using Models;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories
{
    public class ProjectRepository : DataBaseRepository<ProjectEntity, RepositoryContext>, IProjectRepository
    {
        public ProjectRepository(RepositoryContext context) : base(context)
        {
        }

    }
}
