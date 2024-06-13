using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Category
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly ReadilyContext _context;

        public UpdateCategoryValidator(ReadilyContext context) {

            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x).Custom((category, validationContext) =>
            {
                if(category.ParentId.HasValue && category.ChildrenIds != null && category.ChildrenIds.Any())
                {
                    validationContext.AddFailure(nameof(category.ParentId),
                           "Category cannot have both ParentId and ChildrenIds. It must be either a root category or a child category.");
                    validationContext.AddFailure(nameof(category.ChildrenIds),
                            "Category cannot have both ParentId and ChildrenIds. It must be either a root category or a child category.");
                }
            });

            RuleFor(x => x.ParentId)
                .Must(ParentCategoryExists)
                .WithMessage("Parent id doesn't exist.")
                .Must(ValidateCategoryDepth)
                .WithMessage("A category that is already a child cannot have children.");

            RuleFor(x => x.ChildrenIds)
                .Must(ids => ids.Distinct().Count() == ids.Count())
                .WithMessage("Ids of children categories must be distinct.")
                .Must(childrenIds => context.Categories.Where(c => childrenIds.Contains(c.Id) && !c.Children.Any() && c.IsActive).Count() == childrenIds.Count())
                .WithMessage("Some of the provided ChildrenIds do not exist.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Category name is required.")
                .MinimumLength(3)
                .WithMessage("Min number of characters is 3.")
                .Must((dto,name) => !context.Categories.Any(c => c.Name == name && c.Id != dto.Id))
                .WithMessage("Category name is in use.");

        }

        private bool ValidateCategoryDepth(int? parentId)
        {
            // id   name        parentID    output
            //------------------------------------
            // 1    Programming null        true
            // 2    Web         1           true
            // 3    HTML        2           false

            if (parentId == null) return true;
            var category = _context.Categories.Find(parentId);
            return !category.ParentId.HasValue;
        }

        private bool ParentCategoryExists(int? parentId)
        {
            if (parentId == null) return true;

            return _context.Categories.Any(x => x.Id == parentId && x.IsActive);
        }
    }
}
