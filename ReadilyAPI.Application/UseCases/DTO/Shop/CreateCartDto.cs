using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Shop
{
    public class CreateCartDto
    {
        public IEnumerable<BookItem> Items { get; set; }
    }

    public class BookItem
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
