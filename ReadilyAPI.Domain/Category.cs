using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Category : Entity
    {
        #region Properties
        public string Name { get; set; }
        public int? ParentId { get; set; }
        #endregion

        #region Navigation
        public ICollection<Category> Children { get; set; } = new HashSet<Category>();
        public Category Parent { get; set; }
        public ICollection<Book> Books { get; set; } 
        #endregion
    }
}
