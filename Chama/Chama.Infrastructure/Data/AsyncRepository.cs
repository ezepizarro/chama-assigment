using Chama.Core.Entities;
using Chama.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Chama.Infrastructure.Data
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {

        #region Fields

        protected ChamaDbContext Context;

        #endregion

        public AsyncRepository(ChamaDbContext context)
        {
            Context = context;
        }

        #region Public Methods

        public Task<T> GetByIdAsync(int id) => Context.Set<T>().FindAsync(id);

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().FirstOrDefaultAsync(predicate);

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task RemoveAsync(T entity)
        {
            Context.Set<T>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAllAsync() => Context.Set<T>().CountAsync();

        public Task<int> CountWhereAsync(Expression<Func<T, bool>> predicate)
            => Context.Set<T>().CountAsync(predicate);


        #endregion
    }
}
