using Blog.Application.Exceptions;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries.PostQueries;
using Blog.DataAccess;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.PostQueries
{
    public class EFFindPostQuery : EFUseCase, IFindPostQuery
    {
        public EFFindPostQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 17;

        public string Name => "Find Post using EF";

        public PostDto Execute(int id)
        {
            var post = _context.Posts.Include(x => x.User).Include(x => x.Comments).ThenInclude(x => x.ChildComments).Include(x => x.CategoryPosts).ThenInclude(x => x.Category).Include(x => x.TagPosts).ThenInclude(x => x.Tag).FirstOrDefault(x => x.Id == id && x.IsActive);

            if (post == null)
            {
                throw new EntityNotFoundException(id, typeof(Post));
            }

            return new PostDto
            {
                User = post.User.Username,
                Title = post.Title,
                Content = post.Content,
                Comments = post.Comments.TakeWhile(x => x.ChildComments != null).Select(x => new CommentDto { 
                     Content = x.Content,
                     Comments = MethodsForPostQueries.GetChildren(x.Id, _context) ?? new List<CommentDto>()
                     
                }),
                Tags = post.TagPosts.Select(x => new TagDto
                {
                    Name = x.Tag.Name
                }),
                Categories = post.CategoryPosts.Select(x => new CategoryDto
                {
                    Name = x.Category.Name
                })
            };
        }

        
    }
}