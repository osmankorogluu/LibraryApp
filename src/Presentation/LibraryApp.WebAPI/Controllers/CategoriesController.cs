using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.CategoryDto;
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

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(CategoryAddDto categoryAddDto)
        {
            _categoryService.Add(categoryAddDto);
            return Ok();
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(CategoryDto categoryDto)
        {
            _categoryService.Delete(categoryDto);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public IActionResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            _categoryService.Update(categoryUpdateDto);
            return Ok();
        }
    }
}
