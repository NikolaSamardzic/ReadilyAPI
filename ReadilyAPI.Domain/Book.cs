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
        public decimal? Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int ImageId { get; set; } 
        #endregion

        #region Navigation
        public virtual User Author { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Price> Prices { get; set; } = new List<Price>();
        public virtual ICollection<User> Wishlists { get; set; } = new List<User>();
        #endregion
    }
}
