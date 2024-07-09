using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Wishlists;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators
{
    public class CreateWishlistValidator : AbstractValidator<CreateWishlistDto>
    {
        private readonly ReadilyContext _context;

        public CreateWishlistValidator(ReadilyContext context)
        {
            _context = context;

            RuleFor(x => x.BookId)
                .NotEmpty()
                .Must(x => _context.Books.Any(b => b.Id == x && b.IsActive))
                .WithMessage("Book doesn't exist.");
        }
    }
}
