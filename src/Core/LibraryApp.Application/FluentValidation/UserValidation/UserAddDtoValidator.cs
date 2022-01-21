using FluentValidation;
using LibraryApp.Application.Dto.CategoryDto;
using LibraryApp.Application.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.FluentValidation.UserValidation
{
   public class UserAddDtoValidator: AbstractValidator<UserAddDto>
    {
        public UserAddDtoValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().WithMessage("User adı boş geçilemez");
            RuleFor(p => p.UserName).MaximumLength(5).WithMessage("User adı 5 karakterden küçük olamaz");
        }
    }
}
