using ReadilyAPI.Application.UseCases.DTO.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindRoleQuery : IQuery<int, RoleDto>
    {
    }
}
