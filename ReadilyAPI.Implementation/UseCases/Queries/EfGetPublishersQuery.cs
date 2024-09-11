using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
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
    public class EfGetPublishersQuery : EfUseCase, IGetPublishersQuery
    {
        public EfGetPublishersQuery(ReadilyContext context) : base(context)
        {
        }

        private EfGetPublishersQuery() { }

        public int Id => 17;

        public string Name => "Get Publishers";

        public PagedResponse<PublisherDto> Execute(PublisherSearch search)
        {
            var query = Context.Publishers
                                        .Include(x=>x.Books)
                                        .Where(x=>x.IsActive)
                                        .AsQueryable();

            if (!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x=>x.Name.Contains(search.Name));
            }

            if(search.MinBookCount.HasValue && search.MinBookCount.Value > 0)
            {
                query = query.Where(x=>x.Books.Count >= search.MinBookCount.Value);
            }

            if (search.MaxBookCount.HasValue && search.MaxBookCount > 0)
            {
                query = query.Where(x=>x.Books.Count <= search.MaxBookCount.Value);
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<PublisherDto>
            {
                CurrentPage = page,
                Items = query.Select(x => new PublisherDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    BookCount = x.Books.Count,
                }).ToList(),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
