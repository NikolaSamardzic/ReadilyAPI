using AutoMapper;
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
        private readonly IMapper _mapper;

        public EfGetPublishersQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            this._mapper = mapper;
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

            var result = query.Skip(skip).Take(perPage).ToList();

            return new PagedResponse<PublisherDto>
            {
                CurrentPage = page,
                Items = _mapper.Map<IEnumerable<PublisherDto>>(result),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
