using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Image : Entity
    {
        #region Properties
        public string Src { get; set; }
        public string Alt { get; set; } 
        #endregion
    }
}
