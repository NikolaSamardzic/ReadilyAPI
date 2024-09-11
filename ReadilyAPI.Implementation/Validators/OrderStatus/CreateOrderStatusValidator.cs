using FluentValidation;
using ReadilyAPI.Application.UseCases.DTO.OrderStatus;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.OrderStatus
{
    public class CreateOrderStatusValidator : AbstractValidator<CreateOrderStatusDto>
    {
        private readonly ReadilyContext _context;

        public CreateOrderStatusValidator(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Order Status name is required.")
            .MinimumLength(3)
            .WithMessage("Min number of characters is 3.")
            .Must(name => !_context.OrderStatuses.Any(x => x.Name == name))
            .WithMessage("Order Status name is in use.");
        }
    }
}
