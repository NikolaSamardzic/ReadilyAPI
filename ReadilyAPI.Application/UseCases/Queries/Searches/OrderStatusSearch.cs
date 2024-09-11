using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries.Searches
{
    public class OrderStatusSearch : PagedSearch
    {
        public string Name { get; set; }
        public int? MinOrders { get; set; }
        public int? MaxOrders { get; set; }
    }
}
