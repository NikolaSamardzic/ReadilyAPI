using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries.Searches
{
    public class UserSearch : PagedSearch
    {
        public string Keyword { get; set; }
        public int? RoleId { get; set; }
        public bool IsBanned { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
