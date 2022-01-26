using LibraryApp.Application.Dto.UserDto;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("add")]
        [ProducesDefaultResponseType(typeof(UserAddDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddAsync(UserAddDto userAddDto)
        {
            var result = await _userService.AddAsync(userAddDto);
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
        public async Task<IActionResult> DeleteAsync(UserDto userDto)
        {
            var result = await _userService.DeleteAsync(userDto);
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
        [ProducesDefaultResponseType(typeof(UserUpdateDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateAsync(UserUpdateDto categoryUpdateDto)
        {
            var result = await _userService.UpdateAsync(categoryUpdateDto);
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
        [ProducesDefaultResponseType(typeof(List<User>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();
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
        [ProducesDefaultResponseType(typeof(List<User>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
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
