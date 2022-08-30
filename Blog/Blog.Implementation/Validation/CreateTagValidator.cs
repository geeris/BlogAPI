using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validation
{
    public class CreateTagValidator : AbstractValidator<TagDto>
    {
        public CreateTagValidator(BlogContext _context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(30)
                .Matches(@"^[A-Z][a-z]{1,}(\s[A-Z][a-z]{1,})+$")
                .Must(x => _context.Tags.All(t => t.Name != x)).WithMessage("This tag name already exists");
        }
    }
}
