using Blog.Application.UseCases.Commands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases.Commands
{
    public class EFCreateTagCommand : EFUseCase, ICreateTagCommand
    {
        readonly CreateTagValidator _validator;
        public EFCreateTagCommand(BlogContext context, CreateTagValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Create new Tag using EF";

        public void Execute(TagDto request)
        {
            _validator.ValidateAndThrow(request);

            var tag = new Tag
            {
                Name = request.Name
            };

            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}
