using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Queries.UserQueries
{
    public class EFGetUsersQuery : EFUseCase, IGetUsersQuery
    {
        public EFGetUsersQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Get all Users using EF";

        public IEnumerable<UserDto> Execute(UserSearch search)
        {
            //eager loading
            var query = _context.Users.Include(x => x.Role).Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Name))
                query = query.Where(x => x.Name.ToLower().Contains(search.Name.ToLower()));
            if (!string.IsNullOrEmpty(search.Username))
                query = query.Where(x => x.Username.ToLower().Contains(search.Username));

            return query.Select(x => new UserDto
            {
                Username = x.Username,
                Name = x.Name,
                Email = x.Email,
                Image = x.Image,
                RoleName = x.Role.Name
                
            }).ToList();
        }
    }
}
