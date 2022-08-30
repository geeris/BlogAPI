using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands.UserCommands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.UserCommands
{
    public class EFEditUserCommand : EFUseCase, IEditUserCommand
    {
        public EFEditUserCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Edit User using EF";

        public void Execute(UserEditDto request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);

            if (user == null)
                throw new EntityNotFoundException(request.Id, typeof(User));

            if (!string.IsNullOrEmpty(request.Name))
                user.Name = request.Name;
            if (!string.IsNullOrEmpty(request.Email))
                user.Name = request.Email;
            if (!string.IsNullOrEmpty(request.Password))
                user.Name = request.Password;
            //if (!string.IsNullOrEmpty(request.Image))
            //    query.Name = request.Image;

            _context.SaveChanges();
        }
    }
}
