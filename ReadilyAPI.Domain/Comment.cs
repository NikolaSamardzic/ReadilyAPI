using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Comment : Entity
    {
        #region Properties
        public string Text { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        #endregion

        #region Navigation
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
        #endregion
    }
}
