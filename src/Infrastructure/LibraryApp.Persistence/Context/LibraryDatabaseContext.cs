using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Context
{
    public class LibraryDatabaseContext : DbContext
    {
        public LibraryDatabaseContext()
        {
        }
        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> dbContextOptions):base(dbContextOptions)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0A073BJ\\SQLEXPRESS;Database=LibraryApp;Trusted_Connection=true");
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
