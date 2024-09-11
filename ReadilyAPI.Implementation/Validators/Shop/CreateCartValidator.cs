using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Shop
{
    public class CreateCartValidator : AbstractValidator<CreateCartDto>
    {
        private readonly ReadilyContext _context;

        public CreateCartValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Items)
                .NotEmpty()
                .Must(x => x.Count() == x.Select(x => new { Id = x.BookId }).Distinct().Count())
                .WithMessage("BookId must be unique.")
                .Must(x => x.Count() == _context.Books.Where(b => b.IsActive && x.Select(x => x.BookId ).Contains(b.Id)).Count())
                .WithMessage("Book must exist.")
                .Must(x => !x.Any(x => x.Quantity <= 0))
                .WithMessage("Quantity must be greater than 0.");
        }
    }
}
