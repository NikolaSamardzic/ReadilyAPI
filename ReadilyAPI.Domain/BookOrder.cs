using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class BookOrder : Entity
    {
        #region Properties
        public int Quantity { get; set; }
        public int BookId { get; set; }
        public int OrderId { get; set; }
        #endregion

        #region Navigation
        public Book Book { get; set; }
        public Order Order { get; set; }
        #endregion
    }
}
