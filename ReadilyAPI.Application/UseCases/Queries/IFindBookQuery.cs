using ReadilyAPI.Application.UseCases.DTO.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindBookQuery : IQuery<int, BookDto>
    {
    }
}
