using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validation
{
    public class CreatePostValidator : AbstractValidator<CreatePostDto>
    {
        public CreatePostValidator(BlogContext _context)
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .Matches(@"^[A-Z][a-z]{1,}(\s[A-Z][a-z]{1,})+$")
                .Must(x => _context.Posts.All(p => p.Title != x)).WithMessage("This title already exists");

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(10)
                .MaximumLength(2000)
                .Matches(@"^[A-Z][a-z][0-9]{2,}(\s[A-Z][a-z][0-9]{2,})+$");

        }
    }
}
