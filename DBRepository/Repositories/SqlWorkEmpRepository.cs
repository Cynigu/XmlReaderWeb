using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    //public class SqlWorkEmpRepository : BaseRepository, IWorksRepository
    //{
    //    public SqlWorkEmpRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
    //    {
    //    }
    //    public async Task<IEnumerable<WorkEmployee>> Get(int[] ids)
    //    {
    //        List<WorkEmployee> result = new List<WorkEmployee>();

    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            foreach (var id in ids)
    //            {
    //                var work = await context.WorkEmployees.FindAsync(id);
    //                if(work!=null)
    //                    result.Add(work);
    //            }
    //        }

    //        return result;
    //    }
    //    public async Task CreateAsync(WorkEmployee item)
    //    {
    //         using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            await context.WorkEmployees.AddAsync(item);
    //        }
    //    }

    //    public async Task DeleteAsync(int id)
    //    {
    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            WorkEmployee? emp = await context.WorkEmployees.FindAsync(id);
    //            if (emp != null)
    //                context.WorkEmployees.Remove(emp);
    //        }
    //    }

    //    public IEnumerable<WorkEmployee> Get()
    //    {
    //        IEnumerable<WorkEmployee> result;

    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            result = context.WorkEmployees;
    //        }

    //        return result;
    //    }

    //    public async Task<WorkEmployee> Get(int id)
    //    {
    //        WorkEmployee? result;

    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            result = await context.WorkEmployees.FindAsync(id);
    //        }
    //        return result;
    //    }

    //    public async Task SaveAsync()
    //    {
    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            await context.SaveChangesAsync();
    //        }
    //    }

    //    public void Update(WorkEmployee item)
    //    {
    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            context.Entry(item).State = EntityState.Modified;
    //        }
    //    }
    //}
}
