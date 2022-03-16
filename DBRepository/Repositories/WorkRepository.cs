using DBRepository;
using Models;
using XmlReader.Data.DBRepository.Interfaces;

namespace XmlReader.Data.DBRepository.Repositories
{
    public class WorkRepository : DataBaseRepository<WorkEmployee, RepositoryContext>, IWorkRepository
    {
        public WorkRepository(RepositoryContext context) : base(context)
        {
        }

    }
}
