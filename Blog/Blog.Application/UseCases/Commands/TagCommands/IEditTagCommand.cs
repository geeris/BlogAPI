using Blog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Commands.TagCommands
{
    public interface IEditTagCommand : ICommand<TagEditDto>
    {
    }
}
