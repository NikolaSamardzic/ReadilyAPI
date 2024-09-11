using ReadilyAPI.Application.UseCases.DTO.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Shop
{
    public interface ISumbitOrderCommand : ICommand<SubmitOrderDto>
    {
    }
}
