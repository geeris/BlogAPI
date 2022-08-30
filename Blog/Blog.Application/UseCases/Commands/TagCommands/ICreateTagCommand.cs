using Blog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Commands
{
    public interface ICreateTagCommand : ICommand<TagDto>
    {
    }
}
