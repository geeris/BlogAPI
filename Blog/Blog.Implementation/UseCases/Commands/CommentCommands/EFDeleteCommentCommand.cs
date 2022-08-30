using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands.CommentCommands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.CommentCommands
{
    public class EFDeleteCommentCommand : EFUseCase, IDeleteCommentCommand
    {
        public EFDeleteCommentCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Delete Comment using EF";

        public void Execute(int id)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == id);

            if (comment == null)
                throw new EntityNotFoundException(id, typeof(Comment));

            comment.IsActive = false;
            comment.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
