using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands.CategoryCommands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.CategoryCommands
{
    public class EFEditCategoryCommand : EFUseCase, IEditCategoryCommand
    {
        public EFEditCategoryCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Edit Category using EF";

        public void Execute(CategoryEditDto request)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id == request.Id);

            if (category == null)
                throw new EntityNotFoundException(request.Id, typeof(Category));

            category.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
