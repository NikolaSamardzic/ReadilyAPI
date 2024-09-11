using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Audit;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
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
    public class EfGetLogEntriesQuery : EfUseCase, IGetLogEntriesQuery
    {
        public EfGetLogEntriesQuery(ReadilyContext context) : base(context)
        {
        }

        private EfGetLogEntriesQuery() { }

        public int Id => 31;

        public string Name => "Get Log Entries";

        public PagedResponse<LogEntriesDto> Execute(LogEntriesSearch search)
        {
            var query = Context.LogEntries.AsQueryable();

            if (!string.IsNullOrEmpty(search.UseCaseName))
            {
                query = query.Where(x => x.UseCaseName.Contains(search.UseCaseName));
            }

            if (search.ActorId.HasValue && search.ActorId >= 0)
            {
                query = query.Where(x => x.ActorId == search.ActorId);
            }

            if (search.StartTime.HasValue)
            {
                query = query.Where(x => x.CreatedAt > search.StartTime);
            }

            if(search.EndTime.HasValue)
            {
                query = query.Where(x => x.CreatedAt < search.EndTime);
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            return new PagedResponse<LogEntriesDto>
            {
                CurrentPage = page,
                Items = query.Select(x => new LogEntriesDto
                {
                    Id = x.Id,
                    Actor = x.Actor,
                    ActorId = x.ActorId,
                    UseCaseData = x.UseCaseData,
                    USeCaseName = x.UseCaseName,
                    Time = x.CreatedAt
                }).ToList(),
                ItemsPerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
