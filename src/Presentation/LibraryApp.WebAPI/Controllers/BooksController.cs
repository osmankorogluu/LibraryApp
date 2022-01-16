using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.BookDto;
using LibraryApp.Application.FluentValidation;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(BookAddDto bookAddDto)
        {
            _bookService.Add(bookAddDto);
            return Ok();

        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(BookDto bookDto)
        {
            _bookService.Delete(bookDto);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(BookUpdateDto bookUpdateDto)
        {
            _bookService.Update(bookUpdateDto);
            return Ok();
        }

    }
}
