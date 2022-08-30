using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class CategoryPost
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        public Post Post { get; set; }
        public Category Category { get; set; }
    }
}
