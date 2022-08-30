using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases.Commands
{
    public class EFDeleteCategoryCommand : EFUseCase, IDeleteCategoryCommand
    {
        public EFDeleteCategoryCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 10;

        public string Name => "Delete Category using EF";

        public void Execute(int request)
        {
            var category = _context.Categories.Find(request);

            if(category == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
