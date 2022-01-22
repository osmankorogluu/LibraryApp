using FluentValidation;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.BookDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.FluentValidation.BookValidation
{
   public class BookUpdateDtoValidator: AbstractValidator<BookUpdateDto>
    {
        public BookUpdateDtoValidator()
        {
            RuleFor(book => book.BookName).NotEmpty().WithMessage("Kitap ismi boş geçilemez!");
            RuleFor(book => book.BookName).MinimumLength(5).WithMessage("Kitap İsmi 5 karakterden az olamaz!");
            RuleFor(book => book.Stock).NotEmpty().WithMessage("Stok fiyatı boş geçilemez!");
            RuleFor(book => book.Price).NotEmpty().WithMessage("Ürün Fiyatı boş geçilemez!");
        }
    }
}
