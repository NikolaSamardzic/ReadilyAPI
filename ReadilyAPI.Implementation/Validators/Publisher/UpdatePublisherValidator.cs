using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.Publisher;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Publisher
{
    public class UpdatePublisherValidator : AbstractValidator<UpdatePublisherDto>
    {
        private readonly ReadilyContext _context;

        public UpdatePublisherValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Publisher name is required.")
            .MinimumLength(3)
            .WithMessage("Min number of characters is 3.")
            .Must((dto, name) => !_context.Publishers.Any(c => c.Name == name && c.Id != dto.Id))
            .WithMessage("Publisher name is in use.");
        }
    }
}
