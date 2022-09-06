using Blog.Application.UseCases.Commands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using FluentValidation;
using Blog.Implementation.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases.Commands
{
    public class EFCreateCategoryCommand : EFUseCase, ICreateCategoryCommand
    {
        readonly CreateCategoryValidator _validator;
        public EFCreateCategoryCommand(BlogContext context, CreateCategoryValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Create new Category using EF";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = new Category
            {
                Name = request.Name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
