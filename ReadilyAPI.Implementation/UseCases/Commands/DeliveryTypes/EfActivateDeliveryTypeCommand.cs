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
    public class EfActivateDeliveryTypeCommand : EfActivateUseCase<DeliveryType>, IActivateDeliveryTypeCommand
    {
        public EfActivateDeliveryTypeCommand(ReadilyContext context) : base(context)
        {
        }

        private EfActivateDeliveryTypeCommand() { }

        public override int Id => 30;

        public override string Name => "Activate Delivery Type";
    }
}
