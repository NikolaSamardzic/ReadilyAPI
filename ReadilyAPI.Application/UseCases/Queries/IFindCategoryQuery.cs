using ReadilyAPI.Application.UseCases.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindCategoryQuery : IQuery<int,CategoryDto>
    {
    }
}
