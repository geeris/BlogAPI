using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validation
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationDto>
    {
        public UserRegistrationValidator(BlogContext _context)
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(6)
                .MaximumLength(40)
            .Matches("^(?=[a-z0-9._]{6,40}$)(?!.*[_.]{2})[^_.].*[^_.]$").WithMessage("Username should be in all lowercase letters")
            .Must(x => _context.Users.All(u => u.Username != x )).WithMessage("This username has already been taken");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50)
                .Matches(@"^[A-Z][a-z]{2,}(\s[A-Z][a-z]{2,})+$");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .EmailAddress()
            .Must(x=> _context.Users.All(u => u.Email != x)).WithMessage("This email has already been taken");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(6)
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").WithMessage("Password should have one upper, one lower, a number and one special character");
        }
    }
}
