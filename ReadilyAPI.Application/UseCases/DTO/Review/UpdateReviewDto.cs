using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Review
{
    public class UpdateReviewDto : UpdateDto
    {
        public int Stars {  get; set; }
    }
}
