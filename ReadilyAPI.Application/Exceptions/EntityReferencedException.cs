using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.Exceptions
{
    public class EntityReferencedException : Exception
    {
        public EntityReferencedException(int id, string entity) 
            :base($"Cannot delete {entity} with id: {id} because it is referenced by other entities.")
        { 
        
        }
    }
}
