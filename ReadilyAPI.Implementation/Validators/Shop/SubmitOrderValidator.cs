using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ReadilyAPI.Application.UseCases.DTO.Shop;
using ReadilyAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadilyAPI.Implementation.Validators.Shop
{
    public class SubmitOrderValidator : AbstractValidator<SubmitOrderDto>
    {
        private readonly ReadilyContext _context;

        public SubmitOrderValidator(ReadilyContext context) {
            _context = context;

            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.DeliveryTypeId)
                .Must(x => _context.DeliveryTypes.Any(dt => dt.Id == x && dt.IsActive))
                .WithMessage("Delivery type doesn't exist");

            RuleFor(x=> x.AddressName)
                .NotEmpty()
                .Matches("^[a-zšđžćčA-ZŠĐŽĆČ0-9\\s.\\-#\\/,]+$")
                .WithMessage("Please enter a valid address name.");

            RuleFor(x => x.AddressNumber)
                .NotEmpty()
                .Matches("^\\d+[a-zA-Z]?$")
                .WithMessage("Please enter a valid address number.");

            RuleFor(x => x.City)
                .NotEmpty()
                .Matches("^([A-ZŠĐŽĆČ][a-zšđžćč]{2,}\\s?)+$")
                .WithMessage("Incorrect format for city (ex.  Los Angeles)");

            RuleFor(x => x.State)
                .NotEmpty()
                .Matches("^([A-ZŠĐČĆŽ][a-zšđčćž]{2,}\\s?)+$")
                .WithMessage("Incorrect format for state (ex.  California)");

            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(15)
                .WithMessage("Incorrect format for zip code (ex.  90001)");

            RuleFor(x => x.Country)
                .NotEmpty()
                .Matches("^([A-ZŠĐČĆŽ][a-zšđčćž]{2,}\\s?)+$")
                .WithMessage("Incorrect format for country (ex.  United States)");
        }
    }
}
