using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Wishlist;
using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Wishlist
{
    public class EfCreateWishlistCommand : EfCreateUseCase<CreateWishlistDto, Domain.Wishlist>, ICreateWishlistCommand
    {
        private readonly IApplicationActor _actor;

        public EfCreateWishlistCommand(ReadilyContext context, IApplicationActor actor, CreateWishlistValidator validator, IMapper mapper) : base(context, mapper, validator)
        {
            _actor = actor;
        }

        private EfCreateWishlistCommand() { }

        public override int Id => 61;

        public override string Name => "Create Wishlist";

        protected override void BeforeAdd(CreateWishlistDto data)
        {
            data.UserId = _actor.Id;

            if (Context.Users.Include(x => x.Wishlist).First(x => x.Id == _actor.Id).Wishlist.Any(x => x.Id == data.BookId))
            {
                throw new ConflictException("Book already in a wishlist.");
            }
        }
    }
}
