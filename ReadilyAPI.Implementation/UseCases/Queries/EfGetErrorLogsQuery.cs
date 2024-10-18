using AutoMapper;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Audit;
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
            return Context.ErrorLogs
                .WhereIf(search.StartTime.HasValue, x => x.Time > search.StartTime)
                .WhereIf(search.EndTime.HasValue, x => x.Time < search.EndTime)
                .AsPagedReponse<ErrorLog, ErrorLogDto>(search, _mapper);
        }
    }
}
