using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface ISearchCategoriesQuery : IQuery<CategorySearch, IEnumerable<CategoryDto>>
    {
    }
}
