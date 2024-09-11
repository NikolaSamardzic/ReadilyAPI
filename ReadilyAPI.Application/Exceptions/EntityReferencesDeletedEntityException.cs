using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.Exceptions
{
    public class EntityReferencesDeletedEntityException : Exception
    {
        public EntityReferencesDeletedEntityException(int entityId,string entity) 
            :base($"The {entity} with id: {entityId} cannot be activated because it references another deleted entity")
        { }
    }
}
