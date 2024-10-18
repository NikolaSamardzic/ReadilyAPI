using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.Application.UseCases.DTO.Images;
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
    public class EfGetCommentsQuery : EfUseCase, IGetCommentsQuery
    {
        private readonly IMapper _mapper;

        public EfGetCommentsQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfGetCommentsQuery() { }

        public int Id => 57;

        public string Name => "Get Comments";

        public PagedResponse<CommentDto> Execute(CommentSearch search)
        {
            return Context
                .Comments
                .Include(x => x.User)
                .ThenInclude(x => x.Avatar)
                .Include(x => x.Images)
                .Include(x => x.Book)
                .ThenInclude(x => x.Reviews)
                .Where(x => x.IsActive)
                .WhereIf(search.UserId.HasValue, x => x.UserId == search.UserId)
                .WhereIf(search.StartDate.HasValue, x => x.CreatedAt > search.StartDate)
                .WhereIf(search.EndDate.HasValue, x => x.CreatedAt < search.EndDate)
                .AsPagedReponse<Comment, CommentDto>(search, _mapper);
        }
    }
}
