using Blog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Commands.CategoryCommands
{
    public interface IEditCategoryCommand : ICommand<CategoryEditDto>
    {
    }
}
