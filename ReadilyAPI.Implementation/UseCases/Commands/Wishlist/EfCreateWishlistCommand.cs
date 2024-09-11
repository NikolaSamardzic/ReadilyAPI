using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Wishlist;
using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Wishlist
{
    public class EfCreateWishlistCommand : EfUseCase, ICreateWishlistCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateWishlistValidator _validator;

        public EfCreateWishlistCommand(ReadilyContext context, IApplicationActor actor, CreateWishlistValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        private EfCreateWishlistCommand() { }

        public int Id => 61;

        public string Name => "Create Wishlist";

        public void Execute(CreateWishlistDto data)
        {
            _validator.ValidateAndThrow(data);

            if (Context.Users.Include(x => x.Wishlist).First(x=> x.Id == _actor.Id).Wishlist.Any(x => x.Id == data.BookId)) 
            {
                throw new ConflictException("Book already in a wishlist.");
            }

            Context.Wishlists.Add(new Domain.Wishlist
            {
                UserId = _actor.Id,
                BookId = data.BookId,
            });

            Context.SaveChanges();
        }
    }
}
