using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.CategoryDto;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces
{
   public interface ICategoryService
    {
        List<Category> GetAll();
        void Add(CategoryAddDto categoryAddDto);
        void Delete(CategoryDto categoryDto);
        void Update(CategoryUpdateDto categoryUpdateDto);
    }
}
