using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Shop;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ReadilyAPI.Implementation.UseCases.Commands.Shop
{
    public class EfSubmitOrderCommand : EfUpdateUseCase<SubmitOrderDto, Order>, ISumbitOrderCommand
    {
        private readonly IApplicationActor _actor;

        public EfSubmitOrderCommand(ReadilyContext context, IApplicationActor actor, SubmitOrderValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfSubmitOrderCommand() { }

        public override int Id => 66;

        public override string Name => "Submit Order";

        protected override IQueryable<Order> IncludeRelatedEntities(IQueryable<Order> query)
        {
            return query.Where(x => x.UserId == _actor.Id && x.FinishedAt == null);
        }

        protected override void BeforeUpdate(SubmitOrderDto dto, Order entity)
        {
            entity.StatusId = Context.OrderStatuses.First(x => x.Name == "Processing").Id;
        }
    }
}
