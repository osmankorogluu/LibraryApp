using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories.Entityframework
{
    public class EfCategoryRepository : IRepository<Category>
    {
        public void Add(Category entity)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Category entity)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                return context.Set<Category>().SingleOrDefault(filter);
            }
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {

                return filter == null
                    ? context.Set<Category>().ToList()
                    : context.Set<Category>().ToList();
            }
        }

        public void Update(Category entity)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
