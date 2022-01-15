using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Book
            CreateMap<Book, BookDTO>()
               .ForMember(p => p.Name, p1 => p1.MapFrom(x => x.Name));

            CreateMap<BookDTO, Book>();

            //Category
            CreateMap<Category, CategoryDTO>()
                .ForMember(c => c.CategoryName, p1 => p1.MapFrom(x => x.CategoryName));

            CreateMap<CategoryDTO, Category>();

        }
    }
}
