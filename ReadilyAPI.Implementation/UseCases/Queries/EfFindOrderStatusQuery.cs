using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
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
    public class EfFindOrderStatusQuery : EfFindUseCase<OrderStatusDto, OrderStatus>, IFindOrderStatusQuery
    {
        public EfFindOrderStatusQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindOrderStatusQuery() { }

        public override int Id => 22;

        public override string Name => "Find Order Status";

        protected override IQueryable<OrderStatus> IncludeRelatedEntities(IQueryable<OrderStatus> query)
        {
            return query
                .Include(x => x.Orders);
        }
    }
}
