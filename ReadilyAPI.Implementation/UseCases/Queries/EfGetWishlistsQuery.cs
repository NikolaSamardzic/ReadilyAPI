using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetWishlistsQuery : EfUseCase, IGetWishlistQuery
    {
        private readonly IApplicationActor _actor;
        private readonly IMapper _mapper;

        public EfGetWishlistsQuery(ReadilyContext context, IApplicationActor actor, IMapper mapper) : base(context)
        {
            _actor = actor;
            _mapper = mapper;
        }

        private EfGetWishlistsQuery() { }

        public int Id => 63;

        public string Name => "Get Wishlists";

        public PagedResponse<WishlistDto> Execute(WishlistSearch search)
        {
            var wishlist = Context.Wishlists.Where(x => x.UserId == _actor.Id).ToList();

            return Context
                .Books
                .Include(x => x.Image)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Where(x => x.IsActive && wishlist.Select(w => w.BookId).Contains(x.Id))
                .WhereIf(!string.IsNullOrEmpty(search.Keyword),
                x =>
                x.Title.Contains(search.Keyword) || (x.Author.FirstName + x.Author.LastName).Contains(search.Keyword))
                .WhereIf(search.MinPrice.HasValue, x => x.Price > search.MinPrice)
                .WhereIf(search.MaxPrice.HasValue, x => x.Price < search.MaxPrice)
                .WhereIf(search.CategoryIds.Any(), x => x.Categories.Any(c => search.CategoryIds.Contains(c.Id)))
                .AsPagedReponse<Book, WishlistDto>(search, _mapper);
        }
    }
}
