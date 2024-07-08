using ReadilyAPI.Application.UseCases.DTO.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Queries
{
    public interface IFindCommentQuery : IQuery<int, CommentDto>
    {
    }
}
