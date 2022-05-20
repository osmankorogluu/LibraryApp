using AutoMapper;
using Hangfire;
using LibraryApp.Application.ComplexTypes;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.BookDto;
using LibraryApp.Application.FluentValidation;
using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;


        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public string Message { get; set; }

        [HttpPost]
        [Route("add")]
        [ProducesDefaultResponseType(typeof(BookAddDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAsync(BookAddDto bookAddDto)
        {
            Message = $"Logger successful {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(Message);
           
           

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
        public async Task<IActionResult> DeleteAsync(BookDto bookDto)
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
        [ProducesDefaultResponseType(typeof(BookUpdateDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(BookUpdateDto bookUpdateDto)
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
        [ProducesDefaultResponseType(typeof(List<Book>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            Message = $"Logger successful {DateTime.UtcNow.ToLongTimeString()}";
            _logger.LogInformation(Message);


            var result = await _bookService.GetAllAsync();
            if (result.ResultStatus == Persistence.Result.ComplexTypes.ResultStatus.Error)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet]
        [Route("getid")]
        [ProducesDefaultResponseType(typeof(List<Book>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var result = await _bookService.GetBookByIdAsync(id);
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
