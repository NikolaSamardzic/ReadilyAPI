using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Books
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
    }
}
