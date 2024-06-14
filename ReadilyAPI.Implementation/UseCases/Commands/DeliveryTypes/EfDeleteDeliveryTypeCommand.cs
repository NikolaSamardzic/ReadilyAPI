using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.DeliveryTypes;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.DeliveryTypes
{
    public class EfDeleteDeliveryTypeCommand : EfUseCase, IDeleteDeliveryTypeCommand
    {
        public EfDeleteDeliveryTypeCommand(ReadilyContext context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Delete Delivery Type";

        public void Execute(int data)
        {
            var deliveryType = Context.DeliveryTypes.FirstOrDefault(x => x.Id == data && x.IsActive);

            if (deliveryType == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.DeliveryType));
            }

            deliveryType.IsActive = false;

            Context.SaveChanges();
        }
    }
}
