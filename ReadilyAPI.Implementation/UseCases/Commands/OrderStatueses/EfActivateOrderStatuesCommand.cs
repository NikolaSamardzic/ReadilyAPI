using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.OrderStatuses;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.OrderStatueses
{
    public class EfActivateOrderStatuesCommand : EfUseCase, IActivateOrderStatusCommand
    {
        public EfActivateOrderStatuesCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 25;

        public string Name => "Activate Order Status";

        public void Execute(int data)
        {
            var orderStatus = Context.OrderStatuses.FirstOrDefault(x => x.Id == data && !x.IsActive);

            if (orderStatus == null)
            {
                throw new EntityNotFoundException(data, nameof(OrderStatus));
            }

            orderStatus.IsActive = true;

            Context.SaveChanges();
        }
    }
}
