using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindBookQuery : EfUseCase, IFindBookQuery
    {
        public EfFindBookQuery(ReadilyContext context) : base(context)
        {
        }

        public int Id => 49;

        public string Name => "Find Book Use Case";

        public BookDto Execute(int search)
        {
            var book = Context
                .Books
                .Include(x => x.Author)
                .Include(x => x.Image)
                .Include(x => x.BookCategories)
                .ThenInclude(x => x.Category)
                .ThenInclude(x => x.Image)
                .Include(x => x.Reviews)
                .Include(x => x.Publisher)
                .FirstOrDefault(x => x.Id == search && x.IsActive);


            if (book == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.Book));
            }

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Price = (decimal)book.Price,
                Pages = book.PageCount,
                Image = book.Image.Src,
                ReleaseDate = book.ReleaseDate,
                Publisher = book.Publisher.Name,
                Author = new Author
                {
                    Id = book.Author.Id,
                    Name = book.Author.FirstName + " " + book.Author.LastName,
                },
                Rating = new Rating
                {
                    Stars = book.Reviews.Any() ? (int)book.Reviews.Average(x => x.Stars) : 0,
                    Count = book.Reviews.Count
                },
                Categories = book.Categories.Select(x => new Category
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image.Src
                })
            };
        }
    }
}
