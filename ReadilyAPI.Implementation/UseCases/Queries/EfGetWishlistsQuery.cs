using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
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

        public EfGetWishlistsQuery(ReadilyContext context, IApplicationActor actor) : base(context)
        {
            _actor = actor;
        }

        private EfGetWishlistsQuery() { }

        public int Id => 63;

        public string Name => "Get Wishlists";

        public PagedResponse<WishlistDto> Execute(WishlistSearch search)
        {
            var wishlist = Context.Wishlists.Where(x => x.UserId == _actor.Id).ToList();

            var query = Context
                .Books
                .Include(x => x.Image)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Where(x => x.IsActive && wishlist.Select(w => w.BookId).Contains(x.Id))
                .AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword) || (x.Author.FirstName + x.Author.LastName).Contains(search.Keyword));
            }

            if (search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price > search.MinPrice);
            }

            if (search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price < search.MaxPrice);
            }

            if (search.CategoryIds.Any())
            {
                query = query.Where(x => x.Categories.Any(c => search.CategoryIds.Contains(c.Id)));
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<WishlistDto>
            {
                CurrentPage = page,
                ItemsPerPage = perPage,
                TotalCount = totalCount,
                Items = query.Select(x => new WishlistDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image.Src,
                    Price = (decimal)x.Price,
                    Author = new Author
                    {
                        Id = x.Id,
                        Name = x.Author.FirstName + " " + x.Author.LastName,
                    },
                    Rating = new Rating
                    {
                        Stars = x.Reviews.Any() ? (int)x.Reviews.Average(x => x.Stars) : 0,
                        Count = x.Reviews.Count
                    }
                }).ToList()
            };
        }
    }
}
