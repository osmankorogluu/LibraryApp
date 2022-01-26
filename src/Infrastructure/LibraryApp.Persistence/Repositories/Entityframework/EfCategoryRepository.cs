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
    public class EfCategoryRepository : EfRepositoryBase<Category, LibraryDatabaseContext>, ICategoryRepository
    {
        public EfCategoryRepository(LibraryDatabaseContext libraryDatabaseContext):base(libraryDatabaseContext)
        {

        }
    }
}
