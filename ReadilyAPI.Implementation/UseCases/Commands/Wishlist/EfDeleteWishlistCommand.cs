using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Wishlist;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Wishlist
{
    public class EfDeleteWishlistCommand : EfDeleteUseCase<Domain.Wishlist>, IDeleteWishlistCommand
    {
        public EfDeleteWishlistCommand(ReadilyContext context, IApplicationActor actor) : base(context)
        {
        }

        private EfDeleteWishlistCommand() { }

        public override int Id => 62;

        public override string Name => "Delete Wishlist";

        protected override bool IsHardDelete() => true;
    }
}
