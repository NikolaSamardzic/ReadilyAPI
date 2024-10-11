using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.Application.UseCases.DTO.Images;
using ReadilyAPI.Application.UseCases.Queries;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Queries
{
    public class EfFindCommentQuery : EfUseCase, IFindCommentQuery
    {
        private readonly IMapper _mapper;

        public EfFindCommentQuery(ReadilyContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        private EfFindCommentQuery() { }

        public int Id => 56;

        public string Name => "Find Comment";

        public CommentDto Execute(int search)
        {
            var comment = Context
                .Comments
                .Include(x => x.User)
                .ThenInclude(x => x.Avatar)
                .Include(x=>x.Images)
                .Include(x => x.Book)
                .ThenInclude(x => x.Reviews)
                .FirstOrDefault(x => x.Id == search && x.IsActive);

            if(comment == null)
            {
                throw new EntityNotFoundException(search, nameof(Domain.Comment));
            }

            return _mapper.Map<CommentDto>(comment);
        }
    }
}
