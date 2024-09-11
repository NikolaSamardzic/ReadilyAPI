using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.DeliveryType
{
    public class DeliveryTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrdersCount { get; set; }
    }
}
