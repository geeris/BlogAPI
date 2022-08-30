using Blog.Application;
using Blog.Application.Logging;
using Blog.Application.UseCases;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.UseCases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.Logging
{
    public class DatabaseUseCaseLogger : EFUseCase, IUseCaseLogger
    {
        public DatabaseUseCaseLogger(BlogContext context) : base(context)
        {
        }

        public void Log(UseCaseLog log)
        {
            Console.WriteLine($"{DateTime.Now} {log.Actor} is trying to execute {log.UseCaseName} using data : " + $"{JsonConvert.SerializeObject(log.Data ?? string.Empty)}");

            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Date = log.Date,
                UseCaseName = log.UseCaseName,
                Actor = log.Actor,
                Data = JsonConvert.SerializeObject(log.Data),
                IsAuthorized = log.IsAuthorized
                //Data = JsonConvert.SerializeObject(data ?? string.Empty)
            });

            _context.SaveChanges();
        }
    }
}
