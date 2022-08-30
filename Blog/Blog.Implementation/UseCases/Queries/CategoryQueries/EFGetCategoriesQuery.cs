using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blog.Implementation.UseCases.Queries.CategoryQueries
{
    public class EFGetCategoriesQuery : EFUseCase, IGetCategoriesQuery
    {
        public EFGetCategoriesQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Get all Categories using EF";

        public IEnumerable<CategoryDto> Execute(SearchDto search)
        {
            var query = _context.Categories.Where(x => x.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            return query.Select(x => new CategoryDto 
            {
                Name = x.Name 
            }).ToList();
        }
    }
}
