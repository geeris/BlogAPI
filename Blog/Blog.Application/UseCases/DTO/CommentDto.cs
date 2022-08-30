using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.DTO
{
    public class CommentDto
    {
        public string Content { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
    }
}
