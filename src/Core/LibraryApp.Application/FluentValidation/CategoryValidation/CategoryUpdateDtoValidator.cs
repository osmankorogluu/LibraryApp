using FluentValidation;
using LibraryApp.Application.Dto.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.FluentValidation.CategoryValidation
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategory adı boş geçilemez");
            RuleFor(p => p.CategoryName).MaximumLength(5).WithMessage("Kategory adı 5 karakterden küçük olamaz");
        }
    }
}
