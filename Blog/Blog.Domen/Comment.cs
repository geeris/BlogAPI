using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class Comment : Entity
    {
        public string Content { get; set; }
        public int? ParentId { get; set; }

        public int UserId { get; set; }
        public int PostId { get; set; }

        public virtual Comment ParentComment { get; set; }
        public virtual ICollection<Comment> ChildComments { get; set; } = new List<Comment>();

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
