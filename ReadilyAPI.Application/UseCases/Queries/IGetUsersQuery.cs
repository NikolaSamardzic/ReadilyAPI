using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IGetUsersQuery : IQuery<UserSearch, PagedResponse<UserDto>>
    {
    }
}
