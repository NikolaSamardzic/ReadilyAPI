using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
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
            return Context.DeliveryTypes
                                        .Include(x => x.Orders)
                                        .Where(x => x.IsActive)
                                        .WhereIf(!string.IsNullOrEmpty(search.Name), x => x.Name.Contains(search.Name))
                                        .WhereIf(search.MinOrders.HasValue && search.MaxOrders.Value > 0, x => x.Orders.Count() >= search.MinOrders.Value)
                                        .WhereIf(search.MaxOrders.HasValue && search.MaxOrders > 0, x => x.Orders.Count() <= search.MaxOrders.Value)
                                        .AsPagedReponse<DeliveryType, DeliveryTypeDto>(search, _mapper);
        }
    }

}
