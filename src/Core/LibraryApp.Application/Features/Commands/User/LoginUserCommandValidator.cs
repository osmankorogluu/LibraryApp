using FluentValidation;
using LibraryApp.Infrastructure.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Application.Features.Commands.User
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(i => i.EmailAddress)
                .NotNull()
                
                .WithMessage("{PropertyName} not a valid email address");

            RuleFor(i => i.Password)
                .NotNull()
                .MinimumLength(6).WithMessage("{PropertyName} should at laest be {MinLenght} characters");
        }
    }
}
