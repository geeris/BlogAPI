using Blog.Application.UseCases.Commands.CommentCommands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.CommentCommands
{
    public class EFCreateCommentCommand : EFUseCase, ICreateCommentCommand
    {
        public EFCreateCommentCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Create Comment using EF";

        public void Execute(CreateCommentDto request)
        {
            var comment = new Comment
            {
                ParentId = request.ParentId,
                PostId = request.PostId,
                Content = request.Content,
                UserId = 1
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}
