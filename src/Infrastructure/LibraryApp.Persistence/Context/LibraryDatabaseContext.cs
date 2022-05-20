using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Context
{
    public class LibraryDatabaseContext : DbContext
    {
        public LibraryDatabaseContext(DbContextOptions<LibraryDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; private set; }
        public DbSet<Category> Categories { get; private  set; }
        public DbSet<User> Users { get;  set; }
    }
}
