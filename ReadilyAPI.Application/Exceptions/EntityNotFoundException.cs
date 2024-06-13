using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id, string entityType)
            :base($"Entity of type {entityType} with an id of {id} was not found.")
        {
                
        }
    }
}
