using LibraryApp.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories.Entityframework
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>
       where TEntity : BaseEntity, new()

       where TContext : DbContext

    {
        private readonly DbContext dbContext;


        protected DbSet<TEntity> entity => dbContext.Set<TEntity>();

        public EfRepositoryBase(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        public async Task AddAsync(TEntity entity)
        {
            var addedEntity = dbContext.Entry(entity);
            addedEntity.State = EntityState.Added;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await dbContext.SaveChangesAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return dbContext.Set<TEntity>().SingleOrDefault(filter);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
             ? await dbContext.Set<TEntity>().ToListAsync()

               : await dbContext.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var deletedEntity = dbContext.Entry(entity);
            deletedEntity.State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = true, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = entity;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            query = ApplyIncludes(query, includes);

            if (noTracking)
                query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync();

        }
        private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes != null)
            {
                foreach (var includeItem in includes)
                {
                    query = query.Include(includeItem);
                }
            }

            return query;
        }

    }
}



