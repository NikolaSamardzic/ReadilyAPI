using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Category;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Comment
{
    public class CreateCommentValidator : AbstractValidator<CreateCommentDto>
    {
        private readonly ReadilyContext _context;

        public CreateCommentValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.BookId)
                .NotEmpty()
                .Must(x => _context.Books.Any(b => b.Id == x && b.IsActive))
                .WithMessage("Book doesn't exists");

            RuleFor(x => x.Text)
                .NotEmpty()
                .MinimumLength(2);

            When(x => x.Images != null && x.Images.Any(), () =>
            {
                RuleFor(x => x.Images)
                .Must(x => x.Count() < 4)
                .WithMessage("Can't upload more that 3 images.");

                RuleForEach(x => x.Images).Must((x, fileName) =>
                {
                    var path = Path.Combine("wwwroot", "temp", fileName);

                    var exists = Path.Exists(path);

                    return exists;
                }).WithMessage("File doesn't exist.");
            });
        }
    }
}
