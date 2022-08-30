using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Commands.PostCommands
{
    public interface IDeletePostCommand : ICommand<int>
    {
    }
}
