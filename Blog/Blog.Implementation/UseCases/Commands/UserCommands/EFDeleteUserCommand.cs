using Blog.Application.Exceptions;
using Blog.Application.UseCases.Commands.UserCommands;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Commands.UserCommands
{
    public class EFDeleteUserCommand : EFUseCase, IDeleteUserCommand
    {
        public EFDeleteUserCommand(BlogContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Delete account using EF";

        public void Execute(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                throw new EntityNotFoundException(id, typeof(User));

            user.IsActive = false;
            user.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
