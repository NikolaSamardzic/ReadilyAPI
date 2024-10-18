using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetOrderStatusesQuery : EfUseCase, IGetOrderStatusQuery
    {
        private readonly IMapper _mapper;

        public EfGetOrderStatusesQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetOrderStatusesQuery() { }

        public int Id => 23;

        public string Name => "Get Order Statuses";

        public PagedResponse<OrderStatusDto> Execute(OrderStatusSearch search)
        {
            return Context.OrderStatuses
                .Include(x => x.Orders)
                .Where(x => x.IsActive)
                .WhereIf(!string.IsNullOrEmpty(search.Name), x => x.Name.Contains(search.Name))
                .WhereIf(search.MinOrders.HasValue && search.MaxOrders.Value > 0, x => x.Orders.Count() >= search.MinOrders.Value)
                .WhereIf(search.MaxOrders.HasValue && search.MaxOrders > 0, x => x.Orders.Count() <= search.MaxOrders.Value)
                .AsPagedReponse<OrderStatus, OrderStatusDto>(search, _mapper);
        }
    }
}
