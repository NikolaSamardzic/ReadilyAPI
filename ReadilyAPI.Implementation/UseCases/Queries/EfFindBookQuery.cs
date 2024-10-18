using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindBookQuery : EfFindUseCase<BookDto, Book>, IFindBookQuery
    {
        public EfFindBookQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindBookQuery() { }

        public override int Id => 49;

        public override string Name => "Find Book Use Case";

        protected override IQueryable<Book> IncludeRelatedEntities(IQueryable<Book> query)
        {
            return query
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Include(x => x.Image)
                .Include(x => x.BookCategories)
                    .ThenInclude(x => x.Category)
                    .ThenInclude(x => x.Image)
                .Include(x => x.Reviews)
                .Include(x => x.Publisher);
        }
    }
}
