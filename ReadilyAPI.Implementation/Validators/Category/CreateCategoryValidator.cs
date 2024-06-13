using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        private readonly ReadilyContext _context;

        public CreateCategoryValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Category name is required.")
                .MinimumLength(3)
                .WithMessage("Min number of characters is 3.")
                .Must(name => !_context.Categories.Any(c => c.Name == name))
                .WithMessage("Category name is in use.");

            RuleFor(x => x.ParentId)
                .Must(ParentCategoryExists)
                .WithMessage("Parent id doesn't exist.")
                .Must(ValidateCategoryDepth)
                .WithMessage("A category that is already a child cannot have children.");
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
