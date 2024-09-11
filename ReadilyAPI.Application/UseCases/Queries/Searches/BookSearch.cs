using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries.Searches
{
    public class BookSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
    }
}
