using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.CategoryDto;
using LibraryApp.Application.FluentValidation;
using LibraryApp.Application.FluentValidation.CategoryValidation;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Repositories;
using LibraryApp.Persistence.Result.ComplexTypes;
using LibraryApp.Persistence.Result.Concrete;
using LibraryApp.Persistence.Result.Interfaces;
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


        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto)
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
                await _categoryRepository.AddAsync(categoryEntity);
                return new Result(ResultStatus.Success, messages: $"Kategory Başarıyla Eklendi!");
            }
        }

        public async Task<IResult> DeleteAsync(CategoryDto categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.DeleteAsync(categoryEntity);
            return new Result(ResultStatus.Success, messages: $"Kategory Başarıyla Silindi!");
        }

        public async Task<IDataResult<List<Category>>> GetAll()
        {
            var category = await _categoryRepository.GetAll();
            return new DataResult<List<Category>>(ResultStatus.Success, message: "Listelendi!", category);
        }


        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
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
                await _categoryRepository.UpdateAsync(categoryEntity);
                return new Result(ResultStatus.Success, messages: $"Kategory Başarıyla Güncellendi!");
            }


        }
    }
}
