using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Price : Entity
    {
        #region Properties
        public decimal Value { get; set; }
        public int BookId { get; set; }
        #endregion

        #region Navigation
        public Book Book { get; set; }
        #endregion
    }
}
