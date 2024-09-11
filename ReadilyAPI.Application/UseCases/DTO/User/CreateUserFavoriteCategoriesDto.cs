using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.User
{
    public class CreateUserFavoriteCategoriesDto
    {
        public int UserId { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
