using LibraryApp.Application.Dto;
using LibraryApp.Application.Interfaces;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CategoryDTO categoryDTO)
        {
            _categoryService.Add(categoryDTO);
            return Ok();
        }

        [HttpPost("delete")]
        public IActionResult Delete(CategoryDTO categoryDTO)
        {
            _categoryService.Delete(categoryDTO);
            return Ok();
        }

        [HttpPost("update")]
        public IActionResult Update(CategoryDTO categoryDTO)
        {
            _categoryService.Update(categoryDTO);
            return Ok();
        }
    }
}
