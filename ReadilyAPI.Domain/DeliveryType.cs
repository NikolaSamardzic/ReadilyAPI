﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Domain
{
    public class DeliveryType : NamedEntity
    {
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
