using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.Commands.Books;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.DataAccess;
using ReadilyAPI.DataAccess.Migrations;
using ReadilyAPI.Implementation.Validators.Books;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Books
{
    public class EfUpdateBookCommand : EfUseCase, IUpdateBookCommand
    {
        private readonly UpdateBookValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateBookCommand(ReadilyContext context, UpdateBookValidator validator, IMapper mapper) : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        private EfUpdateBookCommand() { }

        public int Id => 46;

        public string Name => "Update Book Use Case";

        public void Execute(UpdateBookDto data)
        {
            _validator.ValidateAndThrow(data);

            var book = Context.Books.Include(x => x.Prices).Single(x => x.Id == data.Id);

            _mapper.Map(data, book);

            var latestPrice = book.Prices.OrderByDescending(p => p.CreatedAt).First().Value;

            if (latestPrice != data.Price)
            {
                book.Prices.Add(new Domain.Price
                {
                    Value = data.Price,
                    BookId = data.Id,
                });

                var orders = Context.Orders
                    .Include(x => x.BookOrders)
                    .Where(x => x.FinishedAt == null && x.BookOrders.Any(bo => bo.BookId == book.Id))
                    .ToList();

                foreach (var order in orders)
                {
                    order.TotalPrice = order.BookOrders.Sum(x => (decimal)x.Book.Price * x.Quantity);
                }
            }

            if (!string.IsNullOrEmpty(data.Image))
            {
                book.Image = new Domain.Image
                {
                    Src = data.Image,
                    Alt = "Book Image"
                };

                var tempFile = Path.Combine("wwwroot", "temp", data.Image);
                var smallerFile = Path.Combine("wwwroot", "images", "books", "small", data.Image);
                var biggerFile = Path.Combine("wwwroot", "images", "books", "large", data.Image);

                using (var originalImage = Image.Load(tempFile))
                {
                    var smallerImage = ResizeImage(originalImage, height: 200);
                    smallerImage.Save(smallerFile);

                    var biggerImage = ResizeImage(originalImage, height: 400);
                    biggerImage.Save(biggerFile);
                }

                System.IO.File.Delete(tempFile);
            }

            Context.SaveChanges();
        }

        private Image ResizeImage(Image originalImage, int height)
        {
            var ratio = (double)height / originalImage.Height;
            var width = (int)(originalImage.Width * ratio);

            var resizedImage = originalImage.Clone(context => context.Resize(new ResizeOptions
            {
                Size = new Size(width, height),
                Mode = ResizeMode.Max
            }));

            return resizedImage;
        }
    }
}
