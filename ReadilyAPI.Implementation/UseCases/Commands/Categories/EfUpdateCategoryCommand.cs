using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Domain;
using ReadilyAPI.Implementation.Validators.Category;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.UseCases.Commands.Categories
{
    public class EfUpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        private readonly UpdateCategoryValidator _validator;

        private readonly IMapper _mapper;

        public EfUpdateCategoryCommand(ReadilyContext context, UpdateCategoryValidator validator, IMapper mapper)
            : base(context)
        {
            _validator = validator;
            _mapper = mapper;
        }

        private EfUpdateCategoryCommand() { }

        public int Id => 3;

        public string Name => "Update Category";

        public void Execute(UpdateCategoryDto data)
        {
            var category = Context.Categories.Include(x => x.Parent).Include(x => x.Children).FirstOrDefault(x => x.Id == data.Id && x.IsActive);

            if (category == null)
            {
                throw new EntityNotFoundException(data.Id.GetValueOrDefault(), nameof(Domain.Category));
            }

            _validator.ValidateAndThrow(data);

            _mapper.Map(data, category);

            var children = Context.Categories.Where(c => data.ChildrenIds.Contains(c.Id)).ToList();
            category.Children = children;

            if (Path.Exists(Path.Combine("wwwroot", "temp", data.Image)))
            {
                category.Image = new Domain.Image
                {
                    Src = data.Image,
                    Alt = "Category Image"
                };

                var tempFile = Path.Combine("wwwroot", "temp", data.Image);
                var destFile = Path.Combine("wwwroot", "images", "categories", data.Image);

                using (var originalImage = SixLabors.ImageSharp.Image.Load(tempFile))
                {
                    var smallerImage = ResizeImage(originalImage, height: 200);
                    smallerImage.Save(destFile);
                }

                System.IO.File.Delete(tempFile);
            }

            Context.Categories.Update(category);

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
