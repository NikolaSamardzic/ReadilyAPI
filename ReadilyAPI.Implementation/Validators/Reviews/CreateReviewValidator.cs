using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Review;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Reviews
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewDto>
    {
        private readonly ReadilyContext _context;

        public CreateReviewValidator(ReadilyContext context)
        {
            _context = context;

            RuleFor(x => x.BookId)
                .NotEmpty()
                .Must(x => _context.Books.Any(b => b.Id == x && b.IsActive))
                .WithMessage("Book doesn't exist");

            RuleFor(x => x.Stars)
                .NotEmpty()
                .Must(x => 0 < x && x < 6)
                .WithMessage("Must be between 1 and 5");
        }
    }
}
