﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Message : Entity
    {
        #region Properties
        public string Subject { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        #endregion

        #region Navigation
        public virtual User User { get; set; } 
        #endregion
    }
}
