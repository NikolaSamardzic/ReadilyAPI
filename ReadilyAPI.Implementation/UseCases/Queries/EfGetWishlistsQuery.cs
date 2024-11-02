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
            return Context.Wishlists
                .Include(x => x.Book)
                .Include(x => x.Book.Author)
                .Include(x => x.Book.Reviews)
                .Include(x => x.Book.Categories)
                .Include(x => x.Book.Image)
                .Where(x => x.UserId == _actor.Id && x.Book.IsActive)
                .WhereIf(!string.IsNullOrEmpty(search.Keyword),
                x =>
                x.Book.Title.Contains(search.Keyword) || (x.Book.Author.FirstName + x.Book.Author.LastName).Contains(search.Keyword))
                .WhereIf(search.MinPrice.HasValue, x => x.Book.Price > search.MinPrice)
                .WhereIf(search.MaxPrice.HasValue, x => x.Book.Price < search.MaxPrice)
                .WhereIf(search.CategoryIds.Any(), x => x.Book.Categories.Any(c => search.CategoryIds.Contains(c.Id)))
                .AsPagedReponse<Wishlist, WishlistDto>(search, _mapper);
        }
    }
}
