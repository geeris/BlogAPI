using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<TagPost> TagPosts { get; set; } = new HashSet<TagPost>();
        public virtual ICollection<CategoryPost> CategoryPosts { get; set; } = new HashSet<CategoryPost>();
    }
}
