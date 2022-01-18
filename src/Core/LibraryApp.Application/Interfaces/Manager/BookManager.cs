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
using LibraryApp.Persistence.Result.ComplexTypes;
using LibraryApp.Persistence.Result.Concrete;
using LibraryApp.Persistence.Result.Interfaces;
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

        public async Task<IResult> AddAsync(BookAddDto bookAddDto)
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
                await _bookRepository.AddAsync(bookEntity);
                return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
            }
        }

        public async Task<IResult> DeleteAsync(BookDto bookDto)
        {
            var bookEntity = _mapper.Map<Book>(bookDto);
            await _bookRepository.DeleteAsync(bookEntity);
            return new Result(ResultStatus.Success, messages: $"Başarıyla Silinmiştir");

        }

        public List<Book> GetAll()
        {
            return _bookRepository.GetAll();
        }

        public async Task<IResult> UpdateAsync(BookUpdateDto bookUpdateDto)
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
                await _bookRepository.UpdateAsync(bookEntity);
                return new Result(ResultStatus.Success, messages: $"Başarıyla Güncelenmiştir.");
            }


        }


    }
}
