using DBRepository.Interfaces;
using Models;

namespace DBRepository.Repositories
{
    public class EmployeeRepository : TEntityRepository<Employee, RepositoryContext>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {
        }

    }
}
