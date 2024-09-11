using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindDeliveryTypeQuery : IQuery<int,DeliveryTypeDto>
    {
    }
}
