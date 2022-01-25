using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Context
{
   public interface ILibraryDatabaseContext
    {

        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
