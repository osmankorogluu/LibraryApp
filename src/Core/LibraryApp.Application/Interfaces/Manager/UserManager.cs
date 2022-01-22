using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LibraryApp.Application.Dto.UserDto;
using LibraryApp.Application.FluentValidation;
using LibraryApp.Application.FluentValidation.UserValidation;
using LibraryApp.Domain.Entities;
using LibraryApp.Persistence.Repositories;
using LibraryApp.Persistence.Repositories.Entityframework;
using LibraryApp.Persistence.Result.ComplexTypes;
using LibraryApp.Persistence.Result.Concrete;
using LibraryApp.Persistence.Result.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Interfaces.Manager
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(UserAddDto userAddDto)
        {
            UserAddDtoValidator validator = new UserAddDtoValidator();

            ValidationResult result = validator.Validate(userAddDto);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            else
            {
                var userEntity = _mapper.Map<User>(userAddDto);
                await _userRepository.AddAsync(userEntity);
                return new Result(ResultStatus.Success, messages: $"Başarıyla Eklendi");
            }
        }

        public async Task<IResult> DeleteAsync(UserDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            await _userRepository.DeleteAsync(userEntity);
            return new Result(ResultStatus.Success, messages: $"Başarıyla Silinmiştir");

        }

        public async Task<IDataResult<List<User>>> GetAll()
        {
            var user = await _userRepository.GetAll();
            return new DataResult<List<User>>(ResultStatus.Success, message: "Listelendi!", user);
        }

        public async Task<IResult> UpdateAsync(UserUpdateDto userUpdateDto)
        {

            UserUpdateValidator validator = new UserUpdateValidator();

            ValidationResult result = validator.Validate(userUpdateDto);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            else
            {
                var bookEntity = _mapper.Map<User>(userUpdateDto);
                await _userRepository.UpdateAsync(bookEntity);
                return new Result(ResultStatus.Success, messages: $"Başarıyla Güncelenmiştir.");
            }
        }
    }
}
