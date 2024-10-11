using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class OrderStatusProfile : Profile
    {
        public OrderStatusProfile() 
        { 
            CreateMap<CreateOrderStatusDto, OrderStatus>();

            CreateMap<UpdateOrderStatusDto, OrderStatus>();

            CreateMap<OrderStatus, OrderStatusDto>()
                .ForMember(d => d.OrdersCount, s => s.MapFrom(x => x.Orders.Count()));
        }
    }
}
