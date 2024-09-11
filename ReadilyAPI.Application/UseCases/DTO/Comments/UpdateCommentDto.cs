using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Comments
{
    public class UpdateCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
