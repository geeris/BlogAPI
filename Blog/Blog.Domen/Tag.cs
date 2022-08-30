using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<TagPost> TagPosts { get; set; } = new HashSet<TagPost>();
    }
}
