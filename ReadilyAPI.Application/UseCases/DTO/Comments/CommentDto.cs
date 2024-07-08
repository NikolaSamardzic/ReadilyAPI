using ReadilyAPI.Application.UseCases.DTO.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Comments
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public IEnumerable<ImageDto> Images { get; set; }
        public UserCommentDto UserComment { get; set; }
    }

    public class UserCommentDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ImageDto Avatar { get; set; }
    }
}
