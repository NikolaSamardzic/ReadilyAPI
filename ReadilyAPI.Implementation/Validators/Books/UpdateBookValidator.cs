using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Books;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Books
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookDto>
    {
        private readonly ReadilyContext _context;

        public UpdateBookValidator(ReadilyContext context) 
        { 
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Must provide value for Id.")
                .Must(x => _context.Books.Any(b => b.Id == x && b.IsActive))
                .WithMessage("Book with specified id doesn't exist.");

            RuleFor(x => x.Title).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.PageCount)
                .NotEmpty()
                .Must(x => x > 1)
                .WithMessage("Must be positive number");

            RuleFor(x => x.Price)
                .NotEmpty()
                .Must(x => x > 1)
                .WithMessage("Must be positive number");

            RuleFor(x => x.ReleaseDate)
                .LessThan(DateTime.UtcNow)
                .WithMessage("Release date must be in the past");

            RuleFor(x => x.PublisherId)
                .NotEmpty()
                .Must(x => _context.Publishers.Any(p => p.Id == x && p.IsActive))
                .WithMessage("Publisher doesn't exist");

            When(x => !string.IsNullOrEmpty(x.Image), () =>
            {
                RuleFor(x => x.Image).Must((x, fileName) =>
                {
                    var path = Path.Combine("wwwroot", "temp", fileName);

                    var exists = Path.Exists(path);

                    return exists;
                }).WithMessage("File doesn't exist.");
            });

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(x => x.Count() ==
                _context.Categories.Where(
                    c => c.IsActive &&
                    c.ParentId != null &&
                    x.Contains(c.Id))
                .Count())
                .WithMessage("Category doesn't exist");
        }
    }
}
