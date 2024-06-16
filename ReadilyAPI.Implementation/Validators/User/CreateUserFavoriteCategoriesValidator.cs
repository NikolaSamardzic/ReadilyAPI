using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.User;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.User
{
    public class CreateUserFavoriteCategoriesValidator : AbstractValidator<CreateUserFavoriteCategoriesDto>
    {
        private readonly ReadilyContext _context;

        public CreateUserFavoriteCategoriesValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x=>x.UserId)
                .NotEmpty()
                .Must(x=> _context.Users.Any(u=>u.Id == x))
                .WithMessage("User doesn't exist");

            RuleFor(x => x.CategoryIds)
                .Must(x => x.Count() == 3)
                .WithMessage("Must provide 3 categories")
                .Must(x => _context.Categories
                                                    .Where(c => x.Contains(c.Id) && c.ParentId == null && c.IsActive).Count() == x.Count())
                .WithMessage("Categories doesn't exist.")
                .Must((dto,ids) =>
                {
                    return !_context.UsersCategories.Any(x => x.UserId == dto.UserId);
                })
                .WithMessage("User already has favorite categories");
        }
    }
}
