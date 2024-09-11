using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Shop
{
    public interface ICreateCartCommand : ICommand<CreateCartDto>
    {
    }
}
