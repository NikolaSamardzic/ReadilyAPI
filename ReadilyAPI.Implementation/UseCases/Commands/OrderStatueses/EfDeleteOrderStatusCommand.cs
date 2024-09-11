using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.OrderStatuses;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.OrderStatueses
{
    public class EfDeleteOrderStatusCommand : EfUseCase, IDeleteOrderStatusCommand
    {
        public EfDeleteOrderStatusCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteOrderStatusCommand() { }

        public int Id => 21;

        public string Name => "Delete Order Status";

        public void Execute(int data)
        {
            var orderStatus = Context.OrderStatuses.FirstOrDefault(x => x.Id == data && x.IsActive);

            if (orderStatus == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.OrderStatus));
            }

            orderStatus.IsActive = false;

            Context.SaveChanges();
        }
    }
}
