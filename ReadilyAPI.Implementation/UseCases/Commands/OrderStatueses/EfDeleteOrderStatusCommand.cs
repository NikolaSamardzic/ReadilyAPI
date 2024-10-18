using Microsoft.EntityFrameworkCore;
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
    public class EfDeleteOrderStatusCommand : EfDeleteUseCase<OrderStatus>, IDeleteOrderStatusCommand
    {
        public EfDeleteOrderStatusCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteOrderStatusCommand() { }

        public override int Id => 21;

        public override string Name => "Delete Order Status";
    }
}
