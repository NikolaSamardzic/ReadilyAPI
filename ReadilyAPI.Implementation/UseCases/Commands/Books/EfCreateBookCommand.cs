using AutoMapper;
using FluentValidation;
using FluentValidation.Internal;
using ReadilyAPI.Application;
using ReadilyAPI.Application.UseCases.Commands.Books;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
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
        private readonly IMapper _mapper;

        public EfCreateBookCommand(ReadilyContext context, IApplicationActor actor, CreateBookValidator validator, IMapper mapper) : base(context)
        {
            _actor = actor;
            _validator = validator;
            _mapper = mapper;
        }

        private EfCreateBookCommand() { }

        public int Id => 45;

        public string Name => "Create Book";

        public void Execute(CreateBookDto data)
        {
            _validator.ValidateAndThrow(data);

            data.AuthorId = _actor.Id;

            Context.Books.Add(_mapper.Map<Book>(data));

            var tempFile = Path.Combine("wwwroot", "temp", data.Image);
            var smallerFile = Path.Combine("wwwroot", "images", "books", "small", data.Image);
            var biggerFile = Path.Combine("wwwroot", "images", "books", "large", data.Image);

            using (var originalImage = SixLabors.ImageSharp.Image.Load(tempFile))
            {
                var smallerImage = ResizeImage(originalImage, height: 200);
                smallerImage.Save(smallerFile);

                var biggerImage = ResizeImage(originalImage, height: 400);
                biggerImage.Save(biggerFile);
            }

            System.IO.File.Delete(tempFile);

            Context.SaveChanges();
        }

        private SixLabors.ImageSharp.Image ResizeImage(SixLabors.ImageSharp.Image originalImage, int height)
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
