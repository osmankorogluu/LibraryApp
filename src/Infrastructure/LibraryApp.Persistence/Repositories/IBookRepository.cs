using AutoMapper;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Context;
using LibraryApp.Persistence.Repositories.Entityframework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
       
    }
}
