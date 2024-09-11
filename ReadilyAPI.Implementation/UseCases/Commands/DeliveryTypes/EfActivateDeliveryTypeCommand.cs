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
    public class EfActivateDeliveryTypeCommand : EfUseCase, IActivateDeliveryTypeCommand
    {
        public EfActivateDeliveryTypeCommand(ReadilyContext context) : base(context)
        {
        }

        private EfActivateDeliveryTypeCommand() { }

        public int Id => 30;

        public string Name => "Activate Delivery Type";

        public void Execute(int data)
        {
            var deliveryType = Context.DeliveryTypes.FirstOrDefault(x => x.Id == data);

            if (deliveryType == null)
            {
                throw new EntityNotFoundException(data, nameof(DeliveryType));
            }

            deliveryType.IsActive = true;

            Context.SaveChanges();
        }
    }
}
