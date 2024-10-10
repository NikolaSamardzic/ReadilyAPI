using AutoMapper;
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
        private readonly IMapper _mapper;

        public EfFindBookQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfFindBookQuery() { }

        public int Id => 49;

        public string Name => "Find Book Use Case";

        public BookDto Execute(int search)
        {
            var book = Context
                .Books
                .Include(x => x.Author)
                .Include(x => x.Comments)
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

            return _mapper.Map<BookDto>(book);
        }
    }
}
