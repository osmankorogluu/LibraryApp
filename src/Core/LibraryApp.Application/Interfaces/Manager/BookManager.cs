using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LibraryApp.Application.AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.BookDto;
using LibraryApp.Application.FluentValidation;
using LibraryApp.Application.FluentValidation.BookValidation;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public BookManager(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public void Add(BookAddDto bookAddDto)
        {
            BookAddDtoValidator validator = new BookAddDtoValidator();

            ValidationResult result = validator.Validate(bookAddDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
                
            }
            else
            {
                var bookEntity = _mapper.Map<Book>(bookAddDto);
                _bookRepository.Add(bookEntity);
            }
        }

        public void Delete(BookDto bookDto)
        {
            var bookEntity = _mapper.Map<Book>(bookDto);
            _bookRepository.Delete(bookEntity);
        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public void Update(BookUpdateDto bookUpdateDto)
        {

            BookUpdateDtoValidator validator = new BookUpdateDtoValidator();

            ValidationResult result = validator.Validate(bookUpdateDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            else
            {
                var bookEntity = _mapper.Map<Book>(bookUpdateDto);
                _bookRepository.Update(bookEntity);
            }
           
        }


    }
}
