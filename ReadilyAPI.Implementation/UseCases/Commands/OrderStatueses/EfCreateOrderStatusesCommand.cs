using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.OrderStatuses;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.OrderStatueses
{
    public class EfCreateOrderStatusesCommand : EfCreateUseCase<CreateOrderStatusDto, OrderStatus>, ICreateOrderStatusCommand
    {
        public EfCreateOrderStatusesCommand(ReadilyContext context, CreateOrderStatusValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfCreateOrderStatusesCommand() { }

        public override int Id => 19;

        public override string Name => "Create Order Status";
    }
}
