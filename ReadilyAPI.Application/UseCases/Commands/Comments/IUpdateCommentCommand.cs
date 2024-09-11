using ReadilyAPI.Application.UseCases.DTO.Comments;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Comments
{
    public interface IUpdateCommentCommand : ICommand<UpdateCommentDto>
    {
    }
}
