using FluentValidation;
using LibraryApp.Application.Dto.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.FluentValidation
{
    public class CategoryAddDtoValidator : AbstractValidator<CategoryAddDto>
    {
        public CategoryAddDtoValidator()
        {
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage("Kategory adı boş geçilemez!");
            RuleFor(p => p.CategoryName).MaximumLength(5).WithMessage("Kategory adı 5 karakterden küçük olamaz!");
        }
    }
}
