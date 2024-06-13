using ReadilyAPI.Application.UseCases.DTO.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Categories
{
    public interface IUpdateCategoryCommand : ICommand<UpdateCategoryDto>
    {
    }
}
