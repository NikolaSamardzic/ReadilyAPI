using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetBooksQuery : EfUseCase, IGetBooksQuery
    {
        public EfGetBooksQuery(ReadilyContext context) : base(context)
        {
        }

        private EfGetBooksQuery() { }

        public int Id => 50;

        public string Name => "Get Books Use Case";

        public PagedResponse<SmallerBookDto> Execute(BookSearch search)
        {
            var query = Context
                .Books
                .Include(x => x.Image)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Where(x => x.IsActive)
                .AsQueryable();

            if(!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Title.Contains(search.Keyword) || (x.Author.FirstName + x.Author.LastName).Contains(search.Keyword));
            }

            if(search.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price > search.MinPrice);
            }

            if(search.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price < search.MaxPrice);
            }

            if(search.CategoryIds.Any())
            {
                query = query.Where(x => x.Categories.Any(c => search.CategoryIds.Contains(c.Id)));
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<SmallerBookDto>
            {
                CurrentPage = page,
                ItemsPerPage = perPage,
                TotalCount = totalCount,
                Items = query.Select(x => new SmallerBookDto
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
