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
    public class EfActivateOrderStatuesCommand : EfActivateUseCase<OrderStatus>, IActivateOrderStatusCommand
    {
        public EfActivateOrderStatuesCommand(ReadilyContext context) : base(context)
        {
        }

        private EfActivateOrderStatuesCommand() { }

        public override int Id => 25;

        public override string Name => "Activate Order Status";
    }
}
