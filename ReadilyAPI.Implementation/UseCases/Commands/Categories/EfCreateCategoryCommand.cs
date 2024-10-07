using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using ReadilyAPI.Implementation.Validators.Category;
using ReadilyAPI.DataAccess.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ReadilyAPI.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        public int Id => 1;

        public string Name => "Create Category";

        private readonly CreateCategoryValidator validator;

        private readonly IMapper mapper;

        public EfCreateCategoryCommand(CreateCategoryValidator validator, ReadilyContext context, IMapper mapper)
            : base(context)
        {
            this.validator = validator;
            this.mapper = mapper;
        }

        private EfCreateCategoryCommand() { }

        public void Execute(CreateCategoryDto data)
        {
            validator.ValidateAndThrow(data);

            Context.Categories.Add(mapper.Map<Domain.Category>(data));

            var tempFile = Path.Combine("wwwroot", "temp", data.Image);
            var destFile = Path.Combine("wwwroot", "images", "categories", data.Image);

            using (var originalImage = Image.Load(tempFile))
            {
                var smallerImage = ResizeImage(originalImage, height: 200);
                smallerImage.Save(destFile);
            }

            System.IO.File.Delete(tempFile);

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
