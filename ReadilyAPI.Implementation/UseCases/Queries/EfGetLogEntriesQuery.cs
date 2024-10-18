using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Audit;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.Application.UseCases.Queries.Searches;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfGetLogEntriesQuery : EfUseCase, IGetLogEntriesQuery
    {
        private readonly IMapper _mapper;

        public EfGetLogEntriesQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetLogEntriesQuery() { }

        public int Id => 31;

        public string Name => "Get Log Entries";

        public PagedResponse<LogEntriesDto> Execute(LogEntriesSearch search)
        {
            return Context.LogEntries
                .WhereIf(!string.IsNullOrEmpty(search.UseCaseName), x => x.UseCaseName.Contains(search.UseCaseName))
                .WhereIf(search.ActorId.HasValue && search.ActorId >= 0, x => x.ActorId == search.ActorId)
                .WhereIf(search.StartTime.HasValue, x => x.CreatedAt > search.StartTime)
                .WhereIf(search.EndTime.HasValue, x => x.CreatedAt < search.EndTime)
                .AsPagedReponse<LogEntry, LogEntriesDto>(search, _mapper);
        }
    }
}
