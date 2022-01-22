using AutoMapper;
using LibraryApp.Application.Dto.CategoryDto;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.AutoMapper.Profiles
{
   public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ForMember(p => p.CategoryName, p1 => p1.MapFrom(x => x.CategoryName)).ReverseMap();
            CreateMap<CategoryAddDto, Category>().ForMember(p => p.CategoryName, p1 => p1.MapFrom(x => x.CategoryName)).ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ForMember(p => p.Id, p1 => p1.MapFrom(x => x.Id)).ReverseMap();
        }
    }
}
