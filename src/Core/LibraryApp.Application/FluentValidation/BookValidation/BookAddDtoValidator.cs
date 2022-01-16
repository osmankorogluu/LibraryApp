﻿using FluentValidation;
using LibraryApp.Application.Dto.BookDto;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.FluentValidation
{
    public class BookAddDtoValidator : AbstractValidator<BookAddDto>
    {
        public BookAddDtoValidator()
        {
            RuleFor(book => book.Name).NotEmpty().WithMessage("Kitap ismi boş geçilemez!");
            RuleFor(book => book.Name).MinimumLength(5).WithMessage("Kitap İsmi 5 karakterden az olamaz!");
            RuleFor(book => book.Stock).NotEmpty().WithMessage("Stok fiyatı boş geçilemez!");
            RuleFor(book => book.Price).NotEmpty().WithMessage("Ürün Fiyatı boş geçilemez!");
        }
    }
}