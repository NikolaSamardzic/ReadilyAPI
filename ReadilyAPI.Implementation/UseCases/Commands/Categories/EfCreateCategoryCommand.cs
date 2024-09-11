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

namespace ReadilyAPI.Implementation.UseCases.Commands.Categories
{
    public class EfCreateCategoryCommand : EfUseCase, ICreateCategoryCommand
    {
        public int Id => 1;

        public string Name => "Create Category";

        private readonly CreateCategoryValidator validator;

        public EfCreateCategoryCommand(CreateCategoryValidator validator, ReadilyContext context)
            : base(context)
        {
            this.validator = validator;
        }

        private EfCreateCategoryCommand() { }

        public void Execute(CreateCategoryDto data)
        {
            validator.ValidateAndThrow(data);

            Context.Categories.Add(new Domain.Category
            {
                Name = data.Name,
                ParentId = data.ParentId,
                Image = new Domain.Image
                {
                    Src = data.Image,
                    Alt = "Category Image"
                }
            });

            var tempFile = Path.Combine("wwwroot", "temp", data.Image);
            var destFile = Path.Combine("wwwroot", "images", "categories", data.Image);

            using (var originalImage = Image.Load(tempFile))
            {
                var smallerImage = ResizeImage(originalImage, height: 200);
                smallerImage.Save(destFile);
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
