using ReadilyAPI.Application.UseCases.DTO.Review;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.Commands.Reviews
{
    public interface ICreateReviewCommand : ICommand<CreateReviewDto>
    {
    }
}
