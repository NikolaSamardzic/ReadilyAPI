using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries.Searches
{
    public class CategorySearch : PagedSearch
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
