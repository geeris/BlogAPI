using Blog.Application.Exceptions;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries.UserQueries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.UserQueries
{
    public class EFFindUserQuery : EFUseCase, IFindUserQuery
    {
        public EFFindUserQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 2;

        public string Name => "Find User using EF";

        public UserDto Execute(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id && x.IsActive);

            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            return new UserDto
            {
                Username = user.Username,
                Name = user.Name,
                Email = user.Email,
                Image = user.Image
            };
        }
    }
}
