using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Review;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Reviews
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewDto>
    {
        private readonly ReadilyContext _context;

        public UpdateReviewValidator(ReadilyContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => _context.Reviews.Any(r => r.Id == x))
                .WithMessage("Review doesn't exist");

            RuleFor(x => x.Stars)
                .NotEmpty()
                .Must(x => 0 < x && x < 6)
                .WithMessage("Must be between 1 and 5");
        }
    }
}
