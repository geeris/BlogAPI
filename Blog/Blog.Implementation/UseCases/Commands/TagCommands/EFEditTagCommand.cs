using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands.TagCommands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.TagCommands
{
    public class EFEditTagCommand : EFUseCase, IEditTagCommand
    {
        public EFEditTagCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 14;

        public string Name => "Edit Tag using EF";

        public void Execute(TagEditDto request)
        {
            var tag = _context.Tags.FirstOrDefault(x=>x.Id == request.Id);

            if (tag == null)
                throw new EntityNotFoundException(request.Id, typeof(Tag));

            tag.Name = request.Name;
            _context.SaveChanges();
        }
    }
}
