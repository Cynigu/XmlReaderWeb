using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository.Repositories
{
    //public class SqlFoldersRepository : BaseRepository, IFoldersRepository
    //{
    //    public SqlFoldersRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
    //    {
    //    }

    //    public async Task CreateAsync(Folder item)
    //    {
    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            await context.Folders.AddAsync(item);
    //        }
    //    }
    //    public async Task<IEnumerable<Folder>> Get(int[] ids)
    //    {
    //        List<Folder> result = new List<Folder>();

    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            foreach (var id in ids)
    //            {
    //                var folder = await context.Folders.FindAsync(id);
    //                if(folder != null)
    //                    result.Add(folder);
    //            }
    //        }

    //        return result;
    //    }
    //    public async Task DeleteAsync(int id)
    //    {
    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            Folder? emp = await context.Folders.FindAsync(id);
    //            if (emp != null)
    //                context.Folders.Remove(emp);
    //        }
    //    }

    //    public IEnumerable<Folder> Get()
    //    {
    //        IEnumerable<Folder> result;

    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            result = context.Folders;
    //        }

    //        return result;
    //    }

    //    public async Task<Folder> Get(int id)
    //    {
    //        Folder? result;

    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            result = await context.Folders.FindAsync(id);
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

    //    public void Update(Folder item)
    //    {
    //        using (var context = ContextFactory.CreateDbContext(_connectionString))
    //        {
    //            context.Entry(item).State = EntityState.Modified;
    //        }
    //    }
    //}
}
