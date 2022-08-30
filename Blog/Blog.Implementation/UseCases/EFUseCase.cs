using Blog.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases
{
    public abstract class EFUseCase
    {
        protected readonly BlogContext _context;

        protected EFUseCase(BlogContext context)
        {
            _context = context;
        }
    }
}
