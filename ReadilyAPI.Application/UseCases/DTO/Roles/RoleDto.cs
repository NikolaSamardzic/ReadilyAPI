using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Roles
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> RoleUseCases { get; set; }
    }
}
