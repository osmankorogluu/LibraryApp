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


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
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

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete(CategoryDto categoryDto)
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
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
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
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
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
