using LibraryApp.Application.Dto;
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
        void Add(CategoryDTO categoryDTO);
        void Delete(CategoryDTO categoryDTO);
        void Update(CategoryDTO categoryDTO);
    }
}
