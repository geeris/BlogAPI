using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands.PostCommands;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.PostCommands
{
    public class EFDeletePostCommand : EFUseCase, IDeletePostCommand
    {
        public EFDeletePostCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Delete Post using EF";

        public void Execute(int id)
        {
            var post = _context.Posts.FirstOrDefault(x => x.Id == id);

            if (post == null)
                throw new EntityNotFoundException(id, typeof(Post));

            post.IsActive = false;
            post.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
