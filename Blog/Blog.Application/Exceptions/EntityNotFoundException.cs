using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        //nas domenski exception
        public EntityNotFoundException(int id, Type type)
            :base($"Entity of type {type.Name} with an id {id} was not found.")
        {
        }
    }
}
