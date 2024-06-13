using FluentValidation;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using ReadilyAPI.DataAccess.Migrations;
using ReadilyAPI.Implementation.Validators.Category;
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

        public void Execute(CreateCategoryDto data)
        {
            validator.ValidateAndThrow(data);

            Context.Categories.Add(new Domain.Category
            {
                Name = data.Name,
                ParentId = data.ParentId,
            });

            Context.SaveChanges();
        }
    }
}
