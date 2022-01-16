using AutoMapper;
using LibraryApp.Application.Dto;
using LibraryApp.Application.Dto.BookDto;
using LibraryApp.Application.Dto.CategoryDto;
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
            CreateMap<BookDto, Book>().ForMember(p => p.Name, p1 => p1.MapFrom(x => x.Name)).ReverseMap();
            CreateMap<BookAddDto, Book>().ForMember(c => c.Name, p => p.MapFrom(x => x.Name)).ReverseMap();
            CreateMap<BookUpdateDto, Book>().ForMember(p => p.Id, p1 => p1.MapFrom(x => x.Id)).ReverseMap();

            //Category
            CreateMap<CategoryDto, Category>().ForMember(p => p.CategoryName, p1 => p1.MapFrom(x => x.CategoryName)).ReverseMap();
            CreateMap<CategoryAddDto, Category>().ForMember(p => p.CategoryName, p1 => p1.MapFrom(x => x.CategoryName)).ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ForMember(p => p.Id, p1 => p1.MapFrom(x => x.Id)).ReverseMap();
        }
    }
}
