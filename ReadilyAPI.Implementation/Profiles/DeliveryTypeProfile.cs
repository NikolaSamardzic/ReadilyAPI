using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class DeliveryTypeProfile : Profile
    {
        public DeliveryTypeProfile() 
        {
            CreateMap<CreateDeliveryTypeDto, DeliveryType>();

            CreateMap<UpdateDeliveryTypeDto, DeliveryType>();

            CreateMap<DeliveryType, DeliveryTypeDto>()
                .ForMember(d => d.OrdersCount, s => s.MapFrom(x => x.Orders.Count()));
        }
    }
}
