using ReadilyAPI.Application.UseCases.DTO.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Books
{
    public interface IUpdateBookCommand : ICommand<UpdateBookDto>
    {
    }
}
