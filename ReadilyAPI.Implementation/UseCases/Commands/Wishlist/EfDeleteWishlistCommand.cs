using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Wishlist;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Wishlist
{
    public class EfDeleteWishlistCommand : EfUseCase, IDeleteWishlistCommand
    {
        private readonly IApplicationActor _actor;

        public EfDeleteWishlistCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        private EfDeleteWishlistCommand() { }

        public int Id => 62;

        public string Name => "Delete Wishlist";

        public void Execute(int data)
        {
            var wishlist = Context
                .Wishlists
                .FirstOrDefault(x => x.BookId == data && x.UserId == _actor.Id);

            if(wishlist == null)
            {
                throw new EntityNotFoundException(data, nameof(Domain.Wishlist));
            }

            Context.Wishlists.Remove(wishlist);

            Context.SaveChanges();
        }
    }
}
