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
    public class EfBookRepository : IRepository<Book>
    {
        public void Add(Book entity)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Book entity)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public Book Get(Expression<Func<Book, bool>> filter)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {
                return context.Set<Book>().SingleOrDefault(filter);
            }
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> filter = null)
        {
            using (LibraryDatabaseContext context = new LibraryDatabaseContext())
            {

                return filter == null
                    ? context.Set<Book>().ToList()
                    : context.Set<Book>().ToList();
            }
        }

        public void Update(Book entity)
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
