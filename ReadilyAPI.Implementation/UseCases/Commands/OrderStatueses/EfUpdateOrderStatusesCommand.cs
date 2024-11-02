using AutoMapper;
using FluentValidation;
using ReadilyAPI.Application.Exceptions;
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
    public class EfUpdateOrderStatusesCommand : EfUpdateUseCase<UpdateOrderStatusDto, OrderStatus>, IUpdateOrderStatusCommand
    {
        public EfUpdateOrderStatusesCommand(ReadilyContext context, UpdateOrderStatusValidatior validator, IMapper mapper) : base(context, mapper, validator)
        {
        }

        private EfUpdateOrderStatusesCommand() { }

        public override int Id => 20;

        public override string Name => "Update Order Status";
    }
}
