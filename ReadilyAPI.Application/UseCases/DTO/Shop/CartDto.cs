using ReadilyAPI.Application.UseCases.DTO.Images;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReadilyAPI.Application.UseCases.DTO.Shop
{
    public class CartDto
    {
        public decimal Total { get; set; }
        public IEnumerable<CartItem> Items { get; set; }
    }

    public class CartItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ImageDto Image { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
