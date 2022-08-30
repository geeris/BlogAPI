using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.DTO
{
    public class PostSearchDto : PagedSearch
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
