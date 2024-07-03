using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Books
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public Author Author { get; set; }
        public Rating Rating { get; set; }
        public decimal Price { get; set; }
        public int Pages { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }

    public class Rating
    {
        public int Stars { get; set; }
        public int Count { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
