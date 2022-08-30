using Blog.Application.Exceptions;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries.CategoryQueries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.CategoryQueries
{
    public class EFFindCategoryQuery : EFUseCase, IFindCategoryQuery
    {
        public EFFindCategoryQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 7;

        public string Name => "Find Category using EF";

        public CategoryDto Execute(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id && x.IsActive);

            if (category == null)
            {
                throw new EntityNotFoundException(id, typeof(Category));
            }

            return new CategoryDto
            {
                Name = category.Name
            };
        }
    }
}
