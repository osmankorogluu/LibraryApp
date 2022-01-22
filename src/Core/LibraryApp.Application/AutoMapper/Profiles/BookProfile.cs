using AutoMapper;
using LibraryApp.Application.Dto.BookDto;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.AutoMapper.Profiles
{
   public class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<BookDto, Book>().ForMember(p => p.Name, p1 => p1.MapFrom(x => x.BookName)).ReverseMap();
            CreateMap<BookAddDto, Book>().ForMember(c => c.Name, p => p.MapFrom(x => x.BookName)).ReverseMap();
            CreateMap<BookUpdateDto, Book>().ForMember(p => p.Id, p1 => p1.MapFrom(x => x.Id)).ReverseMap();
        }
    }
}
