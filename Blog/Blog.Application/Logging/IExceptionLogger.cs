using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Logging
{
    public interface IExceptionLogger
    {
        void Log(Exception ex);
    }
}
