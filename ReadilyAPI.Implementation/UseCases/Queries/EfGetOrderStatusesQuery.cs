using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
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
            var query = Context.OrderStatuses
                                        .Include(x => x.Orders)
                                        .Where(x => x.IsActive)
                                        .AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            if (search.MinOrders.HasValue && search.MaxOrders.Value > 0)
            {
                query = query.Where(x => x.Orders.Count() >= search.MinOrders.Value);
            }

            if (search.MaxOrders.HasValue && search.MaxOrders > 0)
            {
                query = query.Where(x => x.Orders.Count() <= search.MaxOrders.Value);
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            var result = query.Skip(skip).Take(perPage).ToList();

            return new PagedResponse<OrderStatusDto>
            {
                CurrentPage = page,
                Items = _mapper.Map<IEnumerable<OrderStatusDto>>(result),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
