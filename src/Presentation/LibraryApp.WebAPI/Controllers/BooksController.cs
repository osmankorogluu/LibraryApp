﻿using AutoMapper;
using LibraryApp.Application.Dto;
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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _bookService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(BookDTO bookDTO)
        {
            _bookService.Add(bookDTO);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(BookDTO bookDTO)
        {
            _bookService.Delete(bookDTO);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(BookDTO bookDTO)
        {
            _bookService.Update(bookDTO);
            return Ok();
        }

    }
}
