using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Category> Children { get; set; } = new HashSet<Category>();
        public Category Parent { get; set; }
        public ICollection<Book> Books { get; set; }

        // napraviti među tabelu
        // kompozitni primarni ključ
        // zabranjeno brisanje
    }
}
