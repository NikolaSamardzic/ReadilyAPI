using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindCommentQuery : EfFindUseCase<CommentDto, Comment>, IFindCommentQuery
    {
        public EfFindCommentQuery(ReadilyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        private EfFindCommentQuery() { }

        public override int Id => 56;

        public override string Name => "Find Comment";

        protected override IQueryable<Comment> IncludeRelatedEntities(IQueryable<Comment> query)
        {
            return query
                .Include(x => x.User)
                .ThenInclude(x => x.Avatar)
                .Include(x => x.Images)
                .Include(x => x.Book)
                .ThenInclude(x => x.Reviews);
        }
    }
}
