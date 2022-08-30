using Blog.Application;
using Blog.Application.UseCases.Commands.PostCommands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.PostCommands
{
    public class EFCreatePostCommand : EFUseCase, ICreatePostCommand
    {
        readonly CreatePostValidator _validator;
        public EFCreatePostCommand(BlogContext context, CreatePostValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 18;

        public string Name => "Create new Post using EF";

        public void Execute(CreatePostDto request)
        {
            _validator.ValidateAndThrow(request);

            var post = new Post { 
                Title = request.Title,
                Content = request.Content,
                UserId = 1
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}
