using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Review : Entity
    {
        #region Properties
        public int Stars { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        #endregion

        public virtual Book Book { get; set; }
        public virtual User User { get; set;}
    }
}
