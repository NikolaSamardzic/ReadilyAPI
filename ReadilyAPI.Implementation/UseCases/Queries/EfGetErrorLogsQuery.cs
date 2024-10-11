using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Audit;
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
    public class EfGetErrorLogsQuery : EfUseCase, IGetErrorLogsQuery
    {
        private readonly IMapper _mapper;

        public EfGetErrorLogsQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetErrorLogsQuery() { }

        public int Id => 32;

        public string Name => "Get Error Logs";

        public PagedResponse<ErrorLogDto> Execute(ErrorLogSearch search)
        {
            var query = Context.ErrorLogs.AsQueryable();

            if(search.StartTime.HasValue) {
                query = query.Where(x=>x.Time >  search.StartTime);
            }

            if(search.EndTime.HasValue)
            {
                query = query.Where(x => x.Time < search.EndTime);
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            var result = query.Skip(skip).Take(perPage).ToList();

            return new PagedResponse<ErrorLogDto>
            {
                CurrentPage = page,
                Items = _mapper.Map<IEnumerable<ErrorLogDto>>(result),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
