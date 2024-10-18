using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.DeliveryTypes;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.DeliveryTypes
{
    public class EfDeleteDeliveryTypeCommand : EfDeleteUseCase<DeliveryType>, IDeleteDeliveryTypeCommand
    {
        public EfDeleteDeliveryTypeCommand(ReadilyContext context) : base(context)
        {
        }

        private EfDeleteDeliveryTypeCommand() { }

        public override int Id => 27;

        public override string Name => "Delete Delivery Type";
    }
}
