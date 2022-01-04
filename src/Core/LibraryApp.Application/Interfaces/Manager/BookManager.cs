using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces.Manager
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void Add(Book book)
        {
            _bookRepository.Add(book);
        }

        public void Delete(Book book)
        {
            _bookRepository.Delete(book);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
