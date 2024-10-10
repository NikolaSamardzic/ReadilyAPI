using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Comments
{
    public class CreateCommentDto
    {
        public int BookId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}
