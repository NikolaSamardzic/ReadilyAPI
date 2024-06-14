using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ReadilyAPI.Domain
{
    public class OrderStatus : NamedEntity
    {
        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();
    }
}
