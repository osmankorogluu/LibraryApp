using AutoMapper;
using LibraryApp.Infrastructure;
using LibraryApp.Infrastructure.Exceptions;
using LibraryApp.Infrastructure.Models;
using LibraryApp.Infrastructure.RequestModels;
using LibraryApp.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApp.Application.Features.Commands.User
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginUserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            this._configuration = configuration;
            this._userRepository = userRepository;
            this._mapper = mapper;
        }

        public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAddress);

            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");

            var pass = PasswordEncryptor.Encrpt(request.Password);
            if (dbUser.Password != pass)
                throw new DatabaseValidationException("Password is wrong!");

            if (!dbUser.EmailConfirmed)
                throw new DatabaseValidationException("Email address is not confirmed yet!");

            var result = _mapper.Map<LoginUserViewModel>(dbUser);

            var claims = new Claim[]
            {
            new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
            new Claim(ClaimTypes.Email, dbUser.EmailAddress),
            new Claim(ClaimTypes.Name, dbUser.UserName),
            new Claim(ClaimTypes.GivenName, dbUser.FirstName),
            new Claim(ClaimTypes.Surname, dbUser.LastName)
            };

            result.Token = GenerateToken(claims);

            return result;
        }

        private string GenerateToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthConfig:Secret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(claims: claims,
                                             expires: expiry,
                                             signingCredentials: creds,
                                             notBefore: DateTime.Now);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
