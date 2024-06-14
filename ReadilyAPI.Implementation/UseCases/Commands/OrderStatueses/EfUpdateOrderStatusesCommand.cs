using FluentValidation;
using ReadilyAPI.Application.Exceptions;
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
    public class EfUpdateOrderStatusesCommand : EfUseCase, IUpdateOrderStatusCommand
    {
        private readonly UpdateOrderStatusValidatior _validator;

        public EfUpdateOrderStatusesCommand(ReadilyContext context, UpdateOrderStatusValidatior validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 20;

        public string Name => "Update Order Status";

        public void Execute(UpdateOrderStatusDto data)
        {
            _validator.ValidateAndThrow(data);

            var orderStatus = Context.OrderStatuses.FirstOrDefault(x => x.Id == data.Id && x.IsActive);

            if (orderStatus == null)
            {
                throw new EntityNotFoundException(data.Id, nameof(Domain.OrderStatus));
            }

            orderStatus.Name = data.Name;

            Context.SaveChanges();
        }
    }
}
