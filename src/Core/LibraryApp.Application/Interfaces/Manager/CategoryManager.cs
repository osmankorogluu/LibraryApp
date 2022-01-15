using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces.Manager
{
    public class CategoryManager : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryManager(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Add(CategoryDTO categoryDTO)
        {

            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            _categoryRepository.Add(categoryEntity);
        }

        public void Delete(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            _categoryRepository.Delete(categoryEntity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Update(CategoryDTO categoryDTO)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDTO);
            _categoryRepository.Update(categoryEntity);
        }
    }
}
