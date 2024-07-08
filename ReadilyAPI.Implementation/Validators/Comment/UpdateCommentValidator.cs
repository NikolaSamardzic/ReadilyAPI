using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Comments;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Comment
{
    public class UpdateCommentValidator : AbstractValidator<UpdateCommentDto>
    {
        private readonly ReadilyContext _context;

        public UpdateCommentValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(x => _context.Comments.Any(c => c.Id == x && c.IsActive))
                .WithMessage("Comment doesn't exists");

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
