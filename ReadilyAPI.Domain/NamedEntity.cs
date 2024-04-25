using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public abstract class NamedEntity : Entity
    {
        #region Properties
        public string Name { get; set; } 
        #endregion
    }
}
