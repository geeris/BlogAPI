using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.UseCases.DTO
{
    public class PostDto
    {
        public string User { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<CommentDto> Comments { get; set; }
        public IEnumerable<TagDto> Tags { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }

    }
}
