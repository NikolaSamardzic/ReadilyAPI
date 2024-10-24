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
    public class EfCreateCartCommand : EfCreateUseCase<CreateCartDto, BookOrder>, ICreateCartCommand
    {
        private readonly IApplicationActor _actor;

        public EfCreateCartCommand(ReadilyContext context, IApplicationActor actor, CreateCartValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfCreateCartCommand() { }

        public override int Id => 64;

        public override string Name => "Create Cart";

        protected override bool IsAddRange() => true;

        protected override void BeforeAdd(CreateCartDto data)
        {
            var order = Context.Orders.FirstOrDefault(x => x.FinishedAt == null && x.UserId == _actor.Id);

            if (order == null)
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

            var books =
                    Context
                    .Books
                    .Where(x => data.Items.Select(i => i.BookId).Contains(x.Id))
                    .ToList();

            decimal sum = 0;

            foreach (var item in data.Items)
            {
                sum += item.Quantity * (decimal)books.First(x => x.Id == item.BookId).Price;
            }

            order.TotalPrice = sum;
        }
    }
}
