using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.OrderStatuses;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.OrderStatueses
{
    public class EfCreateOrderStatusesCommand : EfUseCase, ICreateOrderStatusCommand
    {
        private readonly CreateOrderStatusValidator _validator;

        public EfCreateOrderStatusesCommand(ReadilyContext context, CreateOrderStatusValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 19;

        public string Name => "Create Order Status";

        public void Execute(CreateOrderStatusDto data)
        {
            _validator.ValidateAndThrow(data);

            Context.OrderStatuses.Add(new Domain.OrderStatus
            {
                Name = data.Name,
            });

            Context.SaveChanges();
        }
    }
}
