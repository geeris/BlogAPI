using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.TagQueries
{
    public class EFGetTagsQuery : EFUseCase, IGetTagsQuery
    {
        public EFGetTagsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 11;

        public string Name => "Get all Tags using EF";

        public IEnumerable<TagDto> Execute(SearchDto search)
        {
            var query = _context.Tags.Where(x => x.IsActive).AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));

            //return query.Select(x => new TagDto 
            //{
            //    Name = x.Name 
            //}).ToList();

            //genericki metod koji bi automaperom ovo radio automatski
            //ovako cemo uvek pisati ovaj kod
            //extension method moze

            return query.Select( x => new TagDto
            {
                Name = x.Name
            }).ToList();
        }
    }
}
