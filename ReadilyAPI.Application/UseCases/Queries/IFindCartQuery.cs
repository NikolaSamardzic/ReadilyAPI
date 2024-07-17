using ReadilyAPI.Application.UseCases.DTO.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindCartQuery : IQuery<int, CartDto>
    {
    }
}
