using ReadilyAPI.Application.UseCases.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IUserProfileQuery : IQuery<int, UserDto>
    {
    }
}
