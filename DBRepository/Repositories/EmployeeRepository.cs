using DBRepository.Interfaces;
using Models;

namespace DBRepository.Repositories
{
    public class EmployeeRepository : TEntityRepository<Employee, RepositoryContext>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task ChangeAsync(int id, Employee item)
        {
            Employee? entity = await _repositoryContext.Employees.FindAsync(id);
            if (entity != null)
            {
                entity.Works = item.Works;
                entity.Name = item.Name;
                entity.IsAdmin = item.IsAdmin;
                entity.NumberPhone = item.NumberPhone;
            }
            await SaveAsync();
        }
    }
}
