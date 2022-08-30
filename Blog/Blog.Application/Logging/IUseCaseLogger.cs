using Blog.Application.UseCases;
using Blog.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Logging
{
    public interface IUseCaseLogger
    {
        void Log(UseCaseLog log);
    }
}
