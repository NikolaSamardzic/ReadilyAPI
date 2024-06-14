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
    public class UpdateOrderStatusValidatior : AbstractValidator<UpdateOrderStatusDto>
    {
        private readonly ReadilyContext _context;

        public UpdateOrderStatusValidatior(ReadilyContext context)
        {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Order Status name is required.")
            .MinimumLength(3)
            .WithMessage("Min number of characters is 3.")
            .Must((dto, name) => !_context.OrderStatuses.Any(c => c.Name == name && c.Id != dto.Id))
            .WithMessage("Order Status name is in use.");
        }
    }
}
