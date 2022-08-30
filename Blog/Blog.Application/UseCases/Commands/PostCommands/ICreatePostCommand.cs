using Blog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Commands.PostCommands
{
    public interface ICreatePostCommand : ICommand<CreatePostDto>
    {
    }
}
