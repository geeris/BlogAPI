using Blog.Application.Exceptions;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries.TagQueries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.TagQueries
{
    public class EFFindTagQuery : EFUseCase, IFindTagQuery
    {
        public EFFindTagQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 12;

        public string Name => "Find Tag using EF";

        public TagDto Execute(int id)
        {
            var tag = _context.Tags.FirstOrDefault(x => x.Id == id && x.IsActive);

            if (tag == null)
            {
                throw new EntityNotFoundException(id, typeof(Tag));
            }

            return new TagDto
            {
                Name = tag.Name
            };
        }
    }
}
