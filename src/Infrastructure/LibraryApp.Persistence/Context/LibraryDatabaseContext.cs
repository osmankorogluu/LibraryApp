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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-0A073BJ\SQLEXPRESS;Database=LibraryApp;Trusted_Connection=true");
        }
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
