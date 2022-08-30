using Blog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Core
{
    public class JwtUser : IApplicationActor
    {
        //nasa implementacija IApplicationUsera
        public int Id { get; set; }

        public string Identity { get; set; }
        public string Username { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
