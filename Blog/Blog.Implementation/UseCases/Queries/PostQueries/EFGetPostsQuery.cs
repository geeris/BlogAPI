using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.Application.UseCases.Queries.PostQueries;
using Blog.DataAccess;
using Blog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.PostQueries
{
    public class EFGetPostsQuery : EFUseCase, IGetPostsQuery
    {
        public EFGetPostsQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 16;

        public string Name => "Get all Posts using EF";

        public PagedResponse<PostDto> Execute(PostSearchDto search)
        {
            //fali uslov za isActive za komentare
            List<Post> posts = new List<Post>();
            var query = _context.Posts.Include(x => x.User).Include(x => x.Comments).ThenInclude(x => x.ChildComments).Include(x => x.CategoryPosts).ThenInclude(x => x.Category).Include(x => x.TagPosts).ThenInclude(x => x.Tag).AsQueryable();

            if (!string.IsNullOrEmpty(search.Title))
                query = query.Where(x => x.Title.ToLower().Contains(search.Title.ToLower()) && x.IsActive);
            if (!string.IsNullOrEmpty(search.Content))
                query = query.Where(x => x.Content.ToLower().Contains(search.Content.ToLower()) && x.IsActive);

            posts = query.ToList();

            var skipCount = search.PerPage * (search.Page - 1);
            var response = new PagedResponse<PostDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = posts.Skip(skipCount).Take(search.PerPage).Select(x => new PostDto
                {
                    User = x.User.Username,
                    Title = x.Title,
                    Content = x.Content,
                    Comments = x.Comments.Where(y => y.ChildComments != null).Select(x => new CommentDto
                    {
                        Content = x.Content,
                        Comments = MethodsForPostQueries.GetChildren(x.Id, _context) ?? new List<CommentDto>()
                    }),
                    Tags = x.TagPosts.Select(x => new TagDto
                    {
                        Name = x.Tag.Name
                    }),
                    Categories = x.CategoryPosts.Select(x => new CategoryDto
                    {
                        Name = x.Category.Name
                    })
                }).ToList()
            };

            return response;
        }
    }
}
