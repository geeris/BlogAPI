using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class ExceptionLog
    {
        public string Guid { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
    }
}
