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

namespace ReadilyAPI.Implementation.UseCases.Commands.Shop
{
    public class EfSubmitOrderCommand : EfUseCase, ISumbitOrderCommand
    {
        private readonly IApplicationActor _actor;
        private readonly SubmitOrderValidator _validator;
        private readonly IMapper _mapper;

        public EfSubmitOrderCommand(ReadilyContext context, IApplicationActor actor, SubmitOrderValidator validator, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }

        private EfSubmitOrderCommand() { }

        public int Id => 66;

        public string Name => "Submit Order";

        public void Execute(SubmitOrderDto data)
        {
            _validator.ValidateAndThrow(data);

            var order = Context.Orders.FirstOrDefault(x => x.UserId == _actor.Id && x.FinishedAt == null);

            if(order == null)
            {
                throw new ConflictException("There is no active order.");
            }

            data.StatusId = Context.OrderStatuses.First(x => x.Name == "Processing").Id;

            _mapper.Map(data, order);

            Context.SaveChanges();
        }
    }
}
