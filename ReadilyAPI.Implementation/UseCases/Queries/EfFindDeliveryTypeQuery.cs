using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindDeliveryTypeQuery : EfUseCase, IFindDeliveryTypeQuery
    {
        public EfFindDeliveryTypeQuery(ReadilyContext context) : base(context)
        {
        }

        public int Id => 28;

        public string Name => "Find Delivery Type";

        public DeliveryTypeDto Execute(int search)
        {
            var deliveryType = Context.DeliveryTypes
                .Include(x => x.Orders)
                .FirstOrDefault(x => x.Id == search && x.IsActive);

            if (deliveryType == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.DeliveryType));
            }

            return new DeliveryTypeDto
            {
                Id = deliveryType.Id,
                Name = deliveryType.Name,
                OrdersCount = deliveryType.Orders.Count()
            };
        }
    }
}
