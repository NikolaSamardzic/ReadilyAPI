using FluentValidation;
using ReadilyAPI.API.DTO.Category;
using ReadilyAPI.DataAccess;

namespace ReadilyAPI.API.Validation
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCatregoryDto>
    {
        private ReadilyContext _context;
        public CreateCategoryDtoValidator(ReadilyContext context) { 
            this._context = context;

            RuleFor(x=> x.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .MinimumLength(3)
                .WithMessage("Min number of characters is 3.")
                .Must(name=>!_context.Categories.Any(c=>c.Name == name))
                .WithMessage("Category name is in use.");

            RuleFor(x=> x.ParentId)
                .Must(ParentCategoryDoesntExistWhenNotNull)
                .WithMessage("Parent id doesn't exist.");
        }

        private bool ParentCategoryDoesntExistWhenNotNull(int? parentId)
        {
            if (!parentId.HasValue)
            {
                return true;
            }

            return _context.Categories.Any(x=>x.ParentId == parentId);
        }
    }
}
