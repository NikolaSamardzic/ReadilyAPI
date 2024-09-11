using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Review
{
    public class CreateReviewDto
    {
        public int BookId { get; set; }
        public int Stars { get; set; }
    }
}
