using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Wishlist
{
    public interface ICreateWishlistCommand : ICommand<CreateWishlistDto>
    {
    }
}
