using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries.Searches
{
    public class PublisherSearch : PagedSearch
    {
        public string Name { get; set; }
        public int? MinBookCount { get; set; }
        public int? MaxBookCount { get; set;}
    }
}
