using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Wishlists
{
    public class WishlistDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public Author Author { get; set; }
        public Rating Rating { get; set; }
        public decimal Price { get; set; }
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
