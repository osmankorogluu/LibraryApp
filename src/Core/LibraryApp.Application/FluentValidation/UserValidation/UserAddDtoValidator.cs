using FluentValidation;
using LibraryApp.Application.Dto.CategoryDto;
using LibraryApp.Application.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryApp.Application.FluentValidation.UserValidation
{
   public class UserAddDtoValidator: AbstractValidator<UserAddDto>
    {
        public UserAddDtoValidator()
        {
           
                RuleFor(x => x.FirstName).NotEmpty().WithMessage("Adınız boş geçilemez");
                RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyadınız boş geçilemez");
                RuleFor(p => p.UserName).NotEmpty().WithMessage("Kulanıcı adınız boş geçilemez.");
                RuleFor(x => x.UserName).Length(0, 10).WithMessage("kulanıcı adınız 10 karakterden büyük olamaz.");
                RuleFor(x => x.EmailAddress).EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");
                RuleFor(x => x.Age).InclusiveBetween(12, 60).WithMessage("Yaşınız 12 altı ve 60 yaş üstü olamaz.");
                RuleFor(customer => customer.Password)
             .NotEmpty().WithMessage("Şifre alanı boş geçilemez!")
             .Must(IsPasswordValid).WithMessage("Şifre en az sekiz karakter, en az bir harf ve bir sayı içermelidir!");

            }

            private bool IsPasswordValid(string arg)
            {
                Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
                return regex.IsMatch(arg);
           }
        }
}

