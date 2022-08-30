using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases.Commands
{
    public class EFDeleteTagCommand : EFUseCase, IDeleteTagCommand
    {
        public EFDeleteTagCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 15;

        public string Name => "Delete Tag using EF";

        public void Execute(int request)
        {
            var tag = _context.Tags.Find(request);

            if(tag == null)
            {
                throw new EntityNotFoundException(request, typeof(Tag));
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }
}
