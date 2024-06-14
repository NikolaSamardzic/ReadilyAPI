using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindOrderStatusQuery : IQuery<int, OrderStatusDto>
    {
    }
}
