using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Shop;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Shop
{
    public class EfCreateCartCommand : EfUseCase, ICreateCartCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateCartValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCartCommand(ReadilyContext context, IApplicationActor actor, CreateCartValidator validator, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }

        private EfCreateCartCommand() { }

        public int Id => 64;

        public string Name => "Create Cart";

        public void Execute(CreateCartDto data)
        {
            _validator.ValidateAndThrow(data);

            var order = Context.Orders.FirstOrDefault(x => x.FinishedAt == null && x.UserId == _actor.Id);

            if(order == null)
            {
                order = new Domain.Order
                {
                    FinishedAt = null,
                    UserId = _actor.Id,
                    TotalPrice = 0,
                    Status = Context.OrderStatuses.First(x => x.Name == "Pending"),
                    AddressId = null,
                    DeliveryTypeId = null,
                };

                Context.Orders.Add(order);
            }

            data.Order = order;

            Context.BooksOrders.AddRange(_mapper.Map<IEnumerable<BookOrder>>(data));

            var books = 
                Context
                .Books
                .Where(x => data.Items.Select(i => i.BookId).Contains(x.Id))
                .ToList();

            decimal sum = 0;

            foreach(var item in data.Items)
            {
                sum += item.Quantity * (decimal)books.First(x => x.Id == item.BookId).Price;
            }

            order.TotalPrice = sum;

            Context.SaveChanges();
        }
    }
}
