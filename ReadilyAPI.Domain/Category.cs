using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Category : NamedEntity
    {
        #region Properties
        public int? ParentId { get; set; }
        #endregion

        #region Navigation
        public virtual ICollection<Category> Children { get; set; } = new HashSet<Category>();
        public virtual Category Parent { get; set; }
        public virtual ICollection<Book> Books { get; set; } 
        #endregion
    }
}
