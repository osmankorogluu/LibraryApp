using LibraryApp.Application.Interfaces;
using LibraryApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LibraryApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImageController : ControllerBase
    {

       private readonly IBookImageService _bookImageService;

        public BookImageController(IBookImageService bookImageService)
        {
            _bookImageService = bookImageService;
        }

        [HttpPost("add")]
        public IActionResult Add(BookImage bookImage, IFormFile file)
        {
            var result = _bookImageService.Add(bookImage, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BookImage bookImage)
        {
            var result = _bookImageService.Update(bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(BookImage bookImage)
        {
            var result = _bookImageService.Delete(bookImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var result = _bookImageService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = _bookImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bookImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        [Route("getbybookid")]
        public IActionResult GetByBookId(string bookId)
        {
            var result = _bookImageService.GetAllByBookId(bookId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
