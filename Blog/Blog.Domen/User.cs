using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<UserUseCase> UseCases { get; set; } = new List<UserUseCase>();


    }
}
