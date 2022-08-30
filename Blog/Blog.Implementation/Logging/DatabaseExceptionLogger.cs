using Blog.Application.Logging;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Logging
{
    public class DatabaseExceptionLogger : EFUseCase, IExceptionLogger
    {
        public DatabaseExceptionLogger(BlogContext context) : base(context)
        {
        }

        public void Log(Exception ex)
        {
            var guid = Guid.NewGuid().ToString();

            _context.ExceptionLogs.Add(new ExceptionLog { 
                Guid = guid,
                Date = DateTime.Now,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                //InnerException = ex.InnerException?.Message ?? string.Empty
                InnerException = ex.InnerException?.Message ?? string.Empty
            });

            _context.SaveChanges();

            //return guid; da prosledimo korisniku
        }
    }
}
