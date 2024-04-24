﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class Publisher : NamedEntity
    {
        public ICollection<Book> Books { get; set; }
    }
}
