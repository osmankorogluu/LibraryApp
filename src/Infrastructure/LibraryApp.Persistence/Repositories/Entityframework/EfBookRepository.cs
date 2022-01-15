using AutoMapper;
using LibraryApp.Domain.Common;
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
    public class EfBookRepository : EfRepositoryBase<Book, LibraryDatabaseContext>, IBookRepository
    {
    }
}