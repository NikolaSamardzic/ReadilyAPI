using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.DeliveryType;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.DeliveryType
{
    public class CreateDeliveryTypeValidator : AbstractValidator<CreateDeliveryTypeDto>
    {
        private readonly ReadilyContext _context;

        public CreateDeliveryTypeValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Delivery Type name is required.")
            .MinimumLength(3)
            .WithMessage("Min number of characters is 3.")
            .Must(name => !_context.DeliveryTypes.Any(x => x.Name == name))
            .WithMessage("Delivery Type name is in use.");
        }
    }
}
