using AutoMapper;
using LibraryApp.Application.ComplexTypes;
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

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(BookAddDto bookAddDto)
        {
            var result = await _bookService.AddAsync(bookAddDto);
            if (result.ResultStatus == Persistence.Result.ComplexTypes.ResultStatus.Error)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(BookDto bookDto)
        {
            var result = await _bookService.DeleteAsync(bookDto);
            if (result.ResultStatus == Persistence.Result.ComplexTypes.ResultStatus.Error)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(BookUpdateDto bookUpdateDto)
        {
            var result = await _bookService.UpdateAsync(bookUpdateDto);
            if (result.ResultStatus == Persistence.Result.ComplexTypes.ResultStatus.Error)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {

            var result = _bookService.GetAll();
            if (result.ResultStatus == Persistence.Result.ComplexTypes.ResultStatus.Error)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
