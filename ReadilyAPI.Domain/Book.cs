using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Book : Entity
    {
        #region Properties
        public string Title { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int AuthotrId { get; set; }
        public int PublisherId { get; set; }
        public int ImageId { get; set; } 
        #endregion

        #region Relations
        public User Author { get; set; }
        public Publisher Publisher { get; set; }
        public Image Image { get; set; }
        public ICollection<Category> Categories { get; set; } 
        #endregion
    }
}
