using AutoMapper;
using LibraryApp.Application.Dto.UserDto;
using LibraryApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.AutoMapper.Profiles
{
   public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ForMember(p => p.FirstName, p1 => p1.MapFrom(x => x.UserName)).ReverseMap();
            CreateMap<UserAddDto, User>().ForMember(p => p.FirstName, p1 => p1.MapFrom(x => x.UserName)).ReverseMap();
            CreateMap<UserUpdateDto, User>().ForMember(p => p.FirstName, p1 => p1.MapFrom(x => x.UserName)).ReverseMap();
        }
    }
}
