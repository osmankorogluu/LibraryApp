using LibraryApp.Application.Dto.UserDto;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Result.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces
{
   public interface IUserService
    {
        Task<IDataResult<List<User>>> GetAllAsync();
        Task<IDataResult<List<User>>> GetUserByIdAsync(int userId);
        Task<IResult> AddAsync(UserAddDto userAddDto);
        Task<IResult> DeleteAsync(UserDto userDto);
        Task<IResult> UpdateAsync(UserUpdateDto userUpdateDto);
    }
}
