using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    public class WorkEmpRepository : TEntityRepository<WorkEmployee, RepositoryContext>, IWorkRepository
    {
        public WorkEmpRepository(RepositoryContext context) : base(context)
        {
        }
    }
}
