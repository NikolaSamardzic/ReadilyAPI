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

        public EfUpdateBookCommand(ReadilyContext context, UpdateBookValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 46;

        public string Name => "Update Book Use Case";

        public void Execute(UpdateBookDto data)
        {
            _validator.ValidateAndThrow(data);

            var book = Context.Books.Find(data.Id);

            book.Title = data.Title;
            book.PageCount = data.PageCount;
            book.ReleaseDate = data.ReleaseDate;
            book.Description = data.Description;
            book.PublisherId = data.PublisherId;

            if(book.Price != data.Price)
            {
                var price = new Domain.Price
                {
                    Book = book,
                    Value = data.Price,
                };

                book.Price = data.Price;

                Context.Prices.Add(price);
            }

            Context.BooksCategories.RemoveRange(Context.BooksCategories.Where(x => x.BookId == data.Id));

            var bookCategories = new List<Domain.BookCategory>();
            foreach (var category in data.CategoryIds)
            {
                var bookCategory = new Domain.BookCategory
                {
                    BookId = book.Id,
                    CategoryId = category
                };
                bookCategories.Add(bookCategory);
            }

            book.BookCategories = bookCategories;

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
