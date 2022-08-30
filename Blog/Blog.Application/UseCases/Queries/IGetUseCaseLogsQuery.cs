using Blog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.Queries
{
    public interface IGetUseCaseLogsQuery : IQuery<UseCaseLogSearchDto, IEnumerable<UseCaseLogDto>>
    {
    }
}
