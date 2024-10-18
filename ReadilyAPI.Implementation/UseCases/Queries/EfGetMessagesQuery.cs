using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Messages;
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
    public class EfGetMessagesQuery : EfUseCase, IGetMessagesQuery
    {
        private readonly IMapper _mapper;

        public EfGetMessagesQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetMessagesQuery() { }

        public int Id => 60;

        public string Name => "Get Messages";

        public PagedResponse<MessageDto> Execute(MessageSearch search)
        {
            return Context
                .Messages
                .Include(x => x.User)
                .Where(x => x.IsActive)
                .WhereIf(search.UserId.HasValue, x => x.UserId == search.UserId)
                .WhereIf(search.StartDate.HasValue, x => x.CreatedAt > search.StartDate)
                .WhereIf(search.EndDate.HasValue, x => x.CreatedAt < search.EndDate)
                .WhereIf(!string.IsNullOrEmpty(search.Keyword), x => x.Subject.Contains(search.Keyword))
                .AsPagedReponse<Message, MessageDto>(search, _mapper);
        }
    }
}
