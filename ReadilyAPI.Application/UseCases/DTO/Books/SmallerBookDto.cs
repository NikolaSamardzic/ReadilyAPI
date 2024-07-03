using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Books
{
    public class SmallerBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public Author Author { get; set; }
        public Rating Rating { get; set; }
        public decimal Price { get; set; }
    }
}
