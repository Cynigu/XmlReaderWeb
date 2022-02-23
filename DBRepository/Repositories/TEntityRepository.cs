using DBRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRepository.Repositories
{
    public class TEntityRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity:  class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext _repositoryContext;
        public TEntityRepository(TContext context)
        {
            _repositoryContext = context;
        }

        public virtual async Task Add(TEntity item)
        {
            await _repositoryContext.Set<TEntity>().AddAsync(item);
            await SaveAsync();
        }

        public virtual async Task<TEntity> Delete(int id)
        {
            TEntity? entity = await _repositoryContext.Set<TEntity>().FindAsync(id);
            if (entity != null)
                _repositoryContext.Set<TEntity>().Remove(entity);
            await SaveAsync();
            return entity;
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _repositoryContext.Set<TEntity>().Where(predicate);
        }

        public virtual IEnumerable<TEntity> Get()
        {
            IEnumerable<TEntity> result;

            result = _repositoryContext.Set<TEntity>();

            return result;
        }

        public virtual async Task<TEntity> Get(int id)
        {
            TEntity? result;
            result = await _repositoryContext.Set<TEntity>().FindAsync(id);
            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> Get(int[] ids)
        {
            List<TEntity> result = new List<TEntity>();


            foreach (var id in ids)
            {
                var entity = await _repositoryContext.Set<TEntity>().FindAsync(id);
                if (entity != null)
                    result.Add(entity);
            }

            return result;
        }

        public virtual async Task SaveAsync()
        {

            await _repositoryContext.SaveChangesAsync();

        }

        public async virtual Task Update(TEntity item)
        {

            _repositoryContext.Entry(item).State = EntityState.Modified;
            await SaveAsync();
        }
    }
}
