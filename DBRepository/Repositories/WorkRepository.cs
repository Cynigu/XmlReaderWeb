using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    public class WorkRepository : TEntityRepository<WorkEmployee, RepositoryContext>, IWorkRepository
    {
        public WorkRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
