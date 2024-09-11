using FluentValidation;
using FluentValidation.Internal;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Books;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.DataAccess;
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
    public class EfCreateBookCommand : EfUseCase, ICreateBookCommand
    {
        private readonly IApplicationActor _actor;
        private readonly CreateBookValidator _validator;

        public EfCreateBookCommand(ReadilyContext context, IApplicationActor actor, CreateBookValidator validator) : base(context)
        {
            _actor = actor;
            _validator = validator;
        }

        private EfCreateBookCommand() { }

        public int Id => 45;

        public string Name => "Create Book";

        public void Execute(CreateBookDto data)
        {
            _validator.ValidateAndThrow(data);


            var book = new Domain.Book
            {
                Title = data.Title,
                Description = data.Description,
                PageCount = data.PageCount,
                ReleaseDate = data.ReleaseDate,
                PublisherId = data.PublisherId,
                AuthorId = _actor.Id,
                Price = data.Price,
                Image = new Domain.Image
                {
                    Src = data.Image,
                    Alt = "Book Image"
                },
            };

            var price = new Domain.Price
            {
                Book = book,
                Value = data.Price,
            };

            Context.Prices.Add(price);

            var bookCategories = new List<Domain.BookCategory>();
            foreach (var category in data.CategoryIds) {
                var bookCategory = new Domain.BookCategory
                {
                    Book = book,
                    CategoryId = category
                };
                bookCategories.Add(bookCategory);
            }

            book.BookCategories = bookCategories;

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

            Context.Books.Add(book);

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
