using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindDeliveryTypeQuery : EfFindUseCase<DeliveryTypeDto, DeliveryType>, IFindDeliveryTypeQuery
    {
        public EfFindDeliveryTypeQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindDeliveryTypeQuery() { }

        public override int Id => 28;

        public override string Name => "Find Delivery Type";

        protected override IQueryable<DeliveryType> IncludeRelatedEntities(IQueryable<DeliveryType> query)
        {
            return query
                .Include(x => x.Orders);
        }
    }
}
