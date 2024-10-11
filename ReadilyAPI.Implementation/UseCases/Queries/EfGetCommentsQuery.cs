using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.Application.UseCases.DTO.Images;
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
            var query = Context
                .Comments
                .Include(x => x.User)
                .ThenInclude(x => x.Avatar)
                .Include(x => x.Images)
                .Include(x => x.Book)
                .ThenInclude(x => x.Reviews)
                .Where(x => x.IsActive)
                .AsQueryable();

            if(search.UserId.HasValue)
            {
                query = query.Where(x => x.UserId == search.UserId);
            }

            if (search.StartDate.HasValue)
            {
                query = query.Where(x => x.CreatedAt > search.StartDate);
            }

            if (search.EndDate.HasValue)
            {
                query = query.Where(x => x.CreatedAt < search.EndDate);
            }

            var totalCount = query.Count();

            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);

            query = query.Skip(skip).Take(perPage);

            var res = query.ToList();

            return new PagedResponse<CommentDto>
            {
                CurrentPage = page,
                ItemsPerPage = perPage,
                TotalCount = totalCount,
                Items = _mapper.Map<IEnumerable<CommentDto>>(res)
            };
        }
    }
}
