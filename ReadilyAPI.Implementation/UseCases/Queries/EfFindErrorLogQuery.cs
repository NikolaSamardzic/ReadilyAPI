using AutoMapper;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Audit;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindErrorLogQuery : EfUseCase, IFindErrorLogQuery
    {
        private readonly IMapper _mapper;

        public EfFindErrorLogQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfFindErrorLogQuery() { }

        public int Id => 33;

        public string Name => "Find Error Log";

        public ErrorLogDto Execute(Guid search)
        {
            var errorLog = Context.ErrorLogs.FirstOrDefault(x => x.Id == search);

            if (errorLog == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.ErrorLog));
            }

            return _mapper.Map<ErrorLogDto>(errorLog);
        }
    }
}
