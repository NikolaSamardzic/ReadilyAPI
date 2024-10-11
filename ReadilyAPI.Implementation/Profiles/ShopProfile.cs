using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Profiles
{
    public class ShopProfile : Profile
    {
        public ShopProfile() 
        {
            CreateMap<CreateCartDto, IEnumerable<BookOrder>>()
                .ConvertUsing((s, d, context) =>
                    s.Items.Select(item => new BookOrder
                    {
                        BookId = item.BookId,
                        Quantity = item.Quantity,
                        Order = s.Order,
                    }));

            CreateMap<Order, CartDto>()
                .ForMember(d => d.Total, s => s.MapFrom(x => x.TotalPrice))
                .ForMember(d => d.Items, s => s.MapFrom(x => x.BookOrders.Select(x => new CartItem
                {
                    Id = x.Id,
                    Title = x.Book.Title,
                    Image = new Application.UseCases.DTO.Images.ImageDto
                    {
                        Alt = x.Book.Image.Alt,
                        Src = x.Book.Image.Src,
                    },
                    UnitPrice = (decimal)x.Book.Price,
                    Price = (decimal)x.Book.Price * x.Quantity,
                    Quantity = x.Quantity,
                })));

            CreateMap<SubmitOrderDto, Order>()
                .ForMember(d => d.Address, s => s.MapFrom(x => new Address
                        {
                            AddressName = x.AddressName,
                            AddressNumber = x.AddressNumber,
                            City = x.City,
                            State = x.State,
                            PostalCode = x.PostalCode,
                            Country = x.Country,
                        }
                ))
                .ForMember(d => d.FinishedAt, s => s.MapFrom(x => DateTime.Now));
        }
    }
}
