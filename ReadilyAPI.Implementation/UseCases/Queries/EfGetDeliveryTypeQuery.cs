using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
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
    public class EfGetDeliveryTypeQuery : EfUseCase, IGetDeliveryTypesQuery
    {
        private readonly IMapper _mapper;

        public EfGetDeliveryTypeQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetDeliveryTypeQuery() { }

        public int Id => 29;

        public string Name => "Get Delivery Types";

        public PagedResponse<DeliveryTypeDto> Execute(DeliveryTypeSearch search)
        {
            var query = Context.DeliveryTypes
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

            return new PagedResponse<DeliveryTypeDto>
            {
                CurrentPage = page,
                Items = _mapper.Map<IEnumerable<DeliveryTypeDto>>(result),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }

}
