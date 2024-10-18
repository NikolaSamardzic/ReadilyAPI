using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Extensions;
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
        private readonly IMapper _mapper;

        public EfGetBooksQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetBooksQuery() { }

        public int Id => 50;

        public string Name => "Get Books Use Case";

        public PagedResponse<SmallerBookDto> Execute(BookSearch search)
        {
            return Context
                .Books
                .Include(x => x.Image)
                .Include(x => x.Author)
                .Include(x => x.Reviews)
                .Where(x => x.IsActive)
                .WhereIf(!string.IsNullOrEmpty(search.Keyword), 
                x => 
                                x.Title.Contains(search.Keyword) || 
                                (x.Author.FirstName + x.Author.LastName).Contains(search.Keyword)
                        )
                .WhereIf(search.MinPrice.HasValue, x => x.Price > search.MinPrice)
                .WhereIf(search.MaxPrice.HasValue, x => x.Price < search.MaxPrice)
                .WhereIf(search.CategoryIds.Any(), x => x.Categories.Any(c => search.CategoryIds.Contains(c.Id)))
                .AsPagedReponse<Book, SmallerBookDto>(search, _mapper);
        }
    }
}
