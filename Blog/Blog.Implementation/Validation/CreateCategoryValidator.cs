using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.Validation
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        public CreateCategoryValidator(BlogContext _context)
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(60)
                .Matches(@"^[A-Z][a-z]{1,}(\s[A-Z][a-z]{1,})+$")
                .Must(x => _context.Categories.All(c => c.Name != x)).WithMessage("This category name already exists");
        }
    }
}
