using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IGetOrderStatusQuery : IQuery<OrderStatusSearch, PagedResponse<OrderStatusDto>>
    {
    }
}
