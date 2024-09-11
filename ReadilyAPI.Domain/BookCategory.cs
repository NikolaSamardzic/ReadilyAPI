using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class BookCategory
    {
        #region Properties
        public int CategoryId { get; set; }
        public int BookId { get; set; }
        #endregion

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}
