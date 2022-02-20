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

        public async Task ChangeAsync(int id, WorkEmployee item)
        {
            WorkEmployee? entity = await _repositoryContext.WorkEmployees.FindAsync(id);
            if (entity != null)
            {
                entity.Description = item.Description;
                entity.BetForObject = item.BetForObject;
                entity.CountFactObject = item.CountFactObject;
                entity.CountFactFiles = item.CountFactFiles;
                entity.CountPlanFiles = item.CountPlanFiles;
                entity.DateStart = item.DateStart;
                entity.DateEnd = item.DateEnd;
                entity.Description = item.Description;
                entity.IsEnd = item.IsEnd;
                entity.Folders = item.Folders;
                entity.SalaryPaid = item.SalaryPaid;
                entity.IsGetSalary = item.IsGetSalary;
            }
            await SaveAsync();
        }
    }
}
