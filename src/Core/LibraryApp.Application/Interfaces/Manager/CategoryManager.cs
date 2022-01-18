using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.CategoryDto;
using LibraryApp.Application.FluentValidation;
using LibraryApp.Application.FluentValidation.CategoryValidation;
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


        public void Add(CategoryAddDto categoryAddDto)
        {
            CategoryAddDtoValidator validator = new CategoryAddDtoValidator();

            ValidationResult result = validator.Validate(categoryAddDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            else
            {
                var categoryEntity = _mapper.Map<Category>(categoryAddDto);
                _categoryRepository.AddAsync(categoryEntity);
            }
        }

        public void Delete(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            _categoryRepository.DeleteAsync(categoryEntity);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public void Update(CategoryUpdateDto categoryUpdateDto)
        {
            CategoryUpdateDtoValidator validator = new CategoryUpdateDtoValidator();
            ValidationResult result = validator.Validate(categoryUpdateDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            else
            {
                var categoryEntity = _mapper.Map<Category>(categoryUpdateDto);
                _categoryRepository.UpdateAsync(categoryEntity);
            }


        }
    }
}
