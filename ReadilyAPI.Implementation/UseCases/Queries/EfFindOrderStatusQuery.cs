﻿using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindOrderStatusQuery : EfUseCase, IFindOrderStatusQuery
    {
        public EfFindOrderStatusQuery(ReadilyContext context) : base(context)
        {
        }

        public int Id => 22;

        public string Name => "Find Order Status";

        public OrderStatusDto Execute(int search)
        {
            var orderStatus = Context.OrderStatuses
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == search && x.IsActive);

            if (orderStatus == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.OrderStatus));
            }

            return new OrderStatusDto
            {
                Id = orderStatus.Id,
                Name = orderStatus.Name,
                OrdersCount = orderStatus.Orders.Count()
            };
        }
    }
}