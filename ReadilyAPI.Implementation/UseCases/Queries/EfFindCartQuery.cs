using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindCartQuery : EfUseCase, IFindCartQuery
    {
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfFindCartQuery(ReadilyContext context, IApplicationActor actor, IMapper mapper) : base(context)
        {
            _actor = actor;
            _mapper = mapper;
        }

        private EfFindCartQuery() { }

        public int Id => 65;

        public string Name => "Find Cart";

        public CartDto Execute(int search)
        {
            var cart = Context
                .Orders
                .Include(o => o.BookOrders)
                .ThenInclude(bo => bo.Book)
                .ThenInclude(b => b.Image)
                .FirstOrDefault(x => x.Id == search && x.StatusId == Context.OrderStatuses.First(os => os.Name == "Pending").Id && x.UserId == _actor.Id);

            if(cart == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.Order));
            }

            return _mapper.Map<CartDto>(cart);
        }
    }
}
