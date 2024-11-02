using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Roles
{
    public class UpdateRoleDto : UpdateDto
    {
        public string Name { get; set; }
        public IEnumerable<int> RoleUseCases { get; set; } = new List<int>();
    }
}
