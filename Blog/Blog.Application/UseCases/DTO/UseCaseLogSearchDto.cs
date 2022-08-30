using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.DTO
{
    public class UseCaseLogSearchDto
    {
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
