using LibraryApp.Application.Dto;
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
        void Add(BookDTO bookDTO);
        void Delete(BookDTO bookDTO);
        void Update(BookDTO bookDTO);
    }
}
