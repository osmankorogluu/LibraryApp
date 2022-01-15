using AutoMapper;
using LibraryApp.Application.AutoMapper;
using LibraryApp.Application.Dto;
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
        private readonly IMapper _mapper;

        public BookManager(IMapper mapper,IBookRepository bookRepository)
        {
            
             _mapper = mapper;
            _bookRepository = bookRepository;
        }

       BookDTO bookDTO = new BookDTO();

        public void Add(Book book)
        {
            var book2 = _mapper.Map<Book>(bookDTO);
            _bookRepository.Add(book2);
        }

        public void Delete(Book book)
        {
            _bookRepository.Delete(book);
        }
       
        public List<Book> GetAll()
        {
            //var config = new MapperConfiguration(cfg => cfg.CreateMap<Book, BookDTO>());
            //var mapper = config.CreateMapper();
            //BookDTO dto = mapper.Map<BookDTO>(Book);

            return  _bookRepository.GetAll();
        }

        public void Update(Book book)
        {
            _bookRepository.Update(book);
        }
    }
}
