using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.CategoryDto;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Result.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IDataResult<List<Category>>> GetAll();
        Task<IResult> AddAsync(CategoryAddDto categoryAddDto);
        Task<IResult> DeleteAsync(CategoryDto categoryDto);
        Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
    }
}
