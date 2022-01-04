using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces
{
   public interface IBookService
    {
        List<Book> GetAll();
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
    }
}
