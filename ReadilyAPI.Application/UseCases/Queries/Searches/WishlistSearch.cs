using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries.Searches
{
    public class WishlistSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
    }
}
