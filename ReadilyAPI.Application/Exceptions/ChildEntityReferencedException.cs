using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.Exceptions
{
    public class ChildEntityReferencedException : Exception
    {
        public ChildEntityReferencedException(int id, int childId, string entity)
            :base($"Cannot delete the {entity} with id: {id} because one of its children with id: {childId} is referenced by other entities.")
        { 
            
        }
    }
}
