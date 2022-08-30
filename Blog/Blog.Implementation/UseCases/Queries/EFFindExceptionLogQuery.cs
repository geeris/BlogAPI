using Blog.Application.Exceptions;
using Blog.Application.UseCases.DTO;
using Blog.Application.UseCases.Queries;
using Blog.DataAccess;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Implementation.UseCases.Queries
{
    public class EFFindExceptionLogQuery : EFUseCase, IFindExceptionLogQuery
    {
        public EFFindExceptionLogQuery(BlogContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Find ExceptionLog using EF";

        public ExceptionLogDto Execute(string guid)
        {
            var exceptionLog = _context.ExceptionLogs.FirstOrDefault(x => x.Guid == guid);

            if (exceptionLog == null)
            {
                //throw new EntityNotFoundException(guid, typeof(ExceptionLog));
            }

            return new ExceptionLogDto
            {
                 Date = exceptionLog.Date,
                 Message = exceptionLog.Message,
                 StackTrace = exceptionLog.StackTrace,
                 InnerException = exceptionLog.InnerException
            };
        }
    }
}
