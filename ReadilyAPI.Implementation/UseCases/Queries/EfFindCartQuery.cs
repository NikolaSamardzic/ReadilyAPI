using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindCartQuery : EfFindUseCase<CartDto, Order>, IFindCartQuery
    {
        private readonly IApplicationActor _actor;

        public EfFindCartQuery(ReadilyContext context, IApplicationActor actor, IMapper mapper) : base(context, mapper)
        {
            _actor = actor;
        }

        private EfFindCartQuery() { }

        public override int Id => 65;

        public override string Name => "Find Cart";

        protected override IQueryable<Order> IncludeRelatedEntities(IQueryable<Order> query)
        {
            return query
                .Include(o => o.BookOrders)
                .ThenInclude(bo => bo.Book)
                .ThenInclude(b => b.Image)
                .Where(x =>x.StatusId == Context.OrderStatuses.First(os => os.Name == "Pending").Id && x.UserId == _actor.Id);
        }
    }
}
