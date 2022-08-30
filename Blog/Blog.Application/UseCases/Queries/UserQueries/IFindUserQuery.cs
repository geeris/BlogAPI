using Blog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Queries.UserQueries
{
    public interface IFindUserQuery : IQuery<int, UserDto>
    {
    }
}
