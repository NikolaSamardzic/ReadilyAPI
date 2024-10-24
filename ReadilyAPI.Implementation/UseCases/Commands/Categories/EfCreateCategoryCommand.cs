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
    public class EfCreateCategoryCommand : EfCreateUseCase<CreateCategoryDto, Domain.Category>, ICreateCategoryCommand
    {
        public EfCreateCategoryCommand(CreateCategoryValidator validator, ReadilyContext context, IMapper mapper)
            : base(context, mapper, validator)
        {
        }

        private EfCreateCategoryCommand() { }

        public override int Id => 1;

        public override string Name => "Create Category";

        protected override void BeforeAdd(CreateCategoryDto data)
        {
            var tempFile = Path.Combine("wwwroot", "temp", data.Image);
            var destFile = Path.Combine("wwwroot", "images", "categories", data.Image);

            using (var originalImage = Image.Load(tempFile))
            {
                var smallerImage = ResizeImage(originalImage, height: 200);
                smallerImage.Save(destFile);
            }

            System.IO.File.Delete(tempFile);
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
