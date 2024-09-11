using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries.Searches
{
    public class RoleSearch : PagedSearch
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
