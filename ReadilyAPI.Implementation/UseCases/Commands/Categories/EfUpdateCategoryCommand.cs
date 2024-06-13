using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.Exceptions;
using ReadilyAPI.Application.UseCases.Commands.Categories;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using ReadilyAPI.Implementation.Validators.Category;
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

        public EfUpdateCategoryCommand(ReadilyContext context, UpdateCategoryValidator validator)
            : base(context)
        {
           _validator = validator;
        }

        public int Id => 3;

        public string Name => "Update Category";

        public void Execute(UpdateCategoryDto data)
        {
            var category = Context.Categories.Include(x=>x.Parent).Include(x=>x.Children).FirstOrDefault(x=> x.Id == data.Id && x.IsActive);

            if (category == null)
            {
                throw new EntityNotFoundException(data.Id.GetValueOrDefault(), nameof(Domain.Category));
            }

            _validator.ValidateAndThrow(data);

            category.Name = data.Name;

            var children = Context.Categories.Where(c => data.ChildrenIds.Contains(c.Id)).ToList();
            category.Children = children;

            var parent = Context.Categories.FirstOrDefault(category => category.Id == data.ParentId);

            category.Parent = parent;

            Context.SaveChanges();
        }
    }
}
