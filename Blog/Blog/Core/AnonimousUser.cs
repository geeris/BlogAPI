using Blog.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Api.Core
{
    public class AnonymousUser : IApplicationActor
    {
        public int Id => 0;
        
        public string Identity => "Anonymous actor";

        public IEnumerable<int> AllowedUseCases => new List<int> { 3};
    }
}
