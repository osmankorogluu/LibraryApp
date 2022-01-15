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

        public void Add(BookDTO bookDTO)
        {
            var bookEntity = _mapper.Map<Book>(bookDTO);
            _bookRepository.Add(bookEntity);
        }

        public void Delete(BookDTO bookDTO)
        {
            var bookEntity = _mapper.Map<Book>(bookDTO);
            _bookRepository.Delete(bookEntity);
        }
       
        public List<Book> GetAll()
        {
            return  _bookRepository.GetAll();
        }

        public void Update(BookDTO bookDTO)
        {
            var bookEntity = _mapper.Map<Book>(bookDTO);
           _bookRepository.Update(bookEntity);
        }
    }
}
