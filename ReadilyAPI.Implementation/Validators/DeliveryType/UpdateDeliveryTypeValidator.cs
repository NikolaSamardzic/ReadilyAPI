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
    public class UpdateDeliveryTypeValidator : AbstractValidator<UpdateDeliveryTypeDto>
    {
        private readonly ReadilyContext _context;

        public UpdateDeliveryTypeValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Delivery Type name is required.")
            .MinimumLength(3)
            .WithMessage("Min number of characters is 3.")
            .Must((dto, name) => !_context.DeliveryTypes.Any(c => c.Name == name && c.Id != dto.Id))
            .WithMessage("Delivery Type name is in use.");
        }
    }
}
