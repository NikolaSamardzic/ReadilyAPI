﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Wishlist
    {
        #region Properites
        public int BookId { get; set; }
        public int UserId { get; set; }
        #endregion

        public virtual Book Book { get; set; }
    }
}
