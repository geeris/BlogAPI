using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.PostQueries
{
    public static class MethodsForPostQueries
    {
        public static Expression<Func<Comment, CommentDto>> GetCommentProjection(int maxDepth, int currentDepth = 0)
        {
            currentDepth++;

            Expression<Func<Comment, CommentDto>> result = comment => new CommentDto()
            {
                Content = comment.Content,
                Comments = currentDepth == maxDepth
                ? new List<CommentDto>()
                : comment.ChildComments.AsQueryable().Select(GetCommentProjection(maxDepth, currentDepth))
                .ToList()
            };

            return result;
        }

        public static List<CommentDto> GetChildren(int parentId, BlogContext _context)
        {
            return _context.Comments
                   .Where(c => c.ParentId == parentId)
                   .Select(GetCommentProjection(7, 0))
                   .ToList();
        }
    }
}
