using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.CategoryDto;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpPost]
        [Route("add")]
        [ProducesDefaultResponseType(typeof(CategoryAddDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAsync(CategoryAddDto categoryAddDto)
        {
            var result = await _categoryService.AddAsync(categoryAddDto);
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
        public async Task<IActionResult> DeleteAsync(CategoryDto categoryDto)
        {
            var result = await _categoryService.DeleteAsync(categoryDto);
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
        [ProducesDefaultResponseType(typeof(CategoryUpdateDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var result = await _categoryService.UpdateAsync(categoryUpdateDto);
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
        [Route("getall")]
        [ProducesDefaultResponseType(typeof(List<Category>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _categoryService.GetAllAsync();
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
        [ProducesDefaultResponseType(typeof(List<Category>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
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
